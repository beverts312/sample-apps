using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;

using WebAPIApplication.Controllers;
using WebAPIApplication.Models;
using WebAPIApplication.Interfaces;
using WebAPIApplication;


namespace Tests
{
    public class NoteControllerTests
    {
        private Mock<INoteAccess> accessMock = new Mock<INoteAccess>();
        private NotesController sut;

        [Fact]
        public async Task GetAllGetsAllsTest()
        {
            var notes = GetNotes();
            accessMock.Setup(x => x.RetrieveNotes()).ReturnsAsync(notes);
            sut = new NotesController(accessMock.Object);
            var res = await sut.Get(null);
            Assert.True(res.Equals(notes));
        }

        [Fact]
        public async Task QueryCallsQueryAll()
        {
            var notes = GetNotes();
            accessMock.Setup(x => x.QueryNotes("somestring")).ReturnsAsync(notes);
            sut = new NotesController(accessMock.Object);
            var res = await sut.Get("somestring");
            Assert.True(res.Equals(notes));
        }

        [Fact]
        public async Task GetByIdCallsGetById()
        {
            var note = new Note(){ id = 1, body = "test" };
            accessMock.Setup(x => x.RetrieveNote("1")).ReturnsAsync(note);
            sut = new NotesController(accessMock.Object);
            var res = await sut.Get(1);
            Assert.Equal(res.id, note.id);
            Assert.Equal(res.body, note.body);
        }

        [Fact]
        public async Task PostCallsAddNote()
        {
            var note = new Note(){ id = 1, body = "test" };
            accessMock.Setup(x => x.AddNote(note.body)).ReturnsAsync(note);
            sut = new NotesController(accessMock.Object);
            var res = await sut.Post(note);
            Assert.Equal(res.id, note.id);
            Assert.Equal(res.body, note.body);
        }
        private IEnumerable<Note> GetNotes()
        {
            return new List<Note>(){
                new Note(){ id = 1, body = "note a" },
                new Note(){ id = 2, body = "note b" },
                new Note(){ id = 3, body = "note c" }
            };
        }
    }
}
