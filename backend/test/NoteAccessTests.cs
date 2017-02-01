using System.Threading.Tasks;
using Xunit;
using Moq;
using StackExchange.Redis;
using System.Linq;
using System.Collections.Generic;
using WebAPIApplication.Models;
using WebAPIApplication;

namespace Tests
{
    public class NoteAccessTests
    {
        private Mock<IConnectionMultiplexer> redisMock = new Mock<IConnectionMultiplexer>();
        private Mock<IServer> serverMock = new Mock<IServer>();
        private Mock<IDatabase> dbMock = new Mock<IDatabase>();
        private NoteAccess sut;

        private string indexKey = "nextIndex";
        private string notesPrefix = "notes_";

        [Fact]
        public async Task AddNoteCallsRedisTest()
        {
            dbMock.Setup(x => x.StringGetAsync(indexKey, CommandFlags.None)).ReturnsAsync("notes_1");
            dbMock.Setup(x => x.StringSetAsync("notes_2", "note", null, When.Always, CommandFlags.None)).ReturnsAsync(true);
            dbMock.Setup(x => x.StringSetAsync(indexKey, "notes_2", null, When.Always, CommandFlags.None)).ReturnsAsync(true);

            sut = new NoteAccess(redisMock.Object, dbMock.Object, serverMock.Object);
            var res = await sut.AddNote("note");

            Assert.Equal(res.body, "note");
        }

        [Fact]
        public async Task RetrieveNoteCallsRedisTest()
        {
            dbMock.Setup(x => x.StringGetAsync("notes_1", CommandFlags.None)).ReturnsAsync("notes");
            sut = new NoteAccess(redisMock.Object, dbMock.Object, serverMock.Object);
            var res = await sut.RetrieveNote("1");

            Assert.Equal(res.body, "notes");
            Assert.Equal(res.id, 1);
        }


        [Fact]
        public async Task RetrieveNotesCallsRedisTest()
        {
            this.setupRetrieveAll();
            sut = new NoteAccess(redisMock.Object, dbMock.Object, serverMock.Object);
            var res = (await sut.RetrieveNotes()).ToList();

            Assert.Equal(res.Count, 1);
            Assert.Equal(res[0].body, "notes");
            Assert.Equal(res[0].id, 1);
        }


        [Fact]
        public async Task QueryNotesDoesntFailIfNoMatchesRedisTest()
        {
            this.setupRetrieveAll();
            sut = new NoteAccess(redisMock.Object, dbMock.Object, serverMock.Object);
            var res = (await sut.QueryNotes("doesntexist")).ToList();

            Assert.Equal(res.Count, 0);
        }


        [Fact]
        public async Task QueryNotesMatchesCharTest()
        {
            this.setupRetrieveAll();
            sut = new NoteAccess(redisMock.Object, dbMock.Object, serverMock.Object);
            var res = (await sut.QueryNotes("n")).ToList();
            
            Assert.Equal(res.Count, 1);
            Assert.Equal(res[0].body, "notes");
            Assert.Equal(res[0].id, 1);
        }

        private void setupRetrieveAll()
        {
            var key = new RedisKey();
            key = key.Append("notes_1");
            serverMock.Setup(x => x.Keys(0, notesPrefix + "*", 10, CommandFlags.None)).Returns(new List<RedisKey>()
            {
                key
            });
            dbMock.Setup(x => x.StringGetAsync(key.ToString(), CommandFlags.None)).ReturnsAsync("notes");

        }
    }
}
