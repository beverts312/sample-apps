using System.Threading.Tasks;
using Xunit;
using Moq;
using StackExchange.Redis;

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
        
    }
}
