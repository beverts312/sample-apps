using Xunit;
using WebAPIApplication.Models;

namespace Tests
{
    public class NoteTests
    {
        [Fact]
        public void BodySetGetTest()
        {
            var expected = "somestring";
            var note = new Note() { body = expected };
            Assert.Equal(note.body, expected);
        }

        [Fact]
        public void IdSetGetTest()
        {
            var expected = 1;
            var note = new Note() { id = expected };

            Assert.Equal(note.id, expected);
        }
    }
}
