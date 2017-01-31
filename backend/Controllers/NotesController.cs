using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private NoteAccess noteAccess = new NoteAccess();

        // GET api/notes
        [HttpGet]
        public async Task<IEnumerable<Note>> Get([FromQueryAttribute]string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                return await noteAccess.RetrieveNotes();
            }
            else
            {
                return await noteAccess.QueryNotes(query);
            }
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public async Task<Note> Get(int id)
        {
            return await noteAccess.RetrieveNote(Convert.ToString(id));
        }

        // POST api/notes
        [HttpPost]
        public async Task<Note> Post([FromBody]Note note)
        {
            return await noteAccess.AddNote(note.body);
        }
    }
}
