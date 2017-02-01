using System.Collections.Generic;
using System.Threading.Tasks;

using WebAPIApplication.Models;

namespace WebAPIApplication.Interfaces
{
    public interface INoteAccess
    {
        Task<Note> AddNote(string note);
        
        Task<Note> RetrieveNote(string id);
        
        Task<IEnumerable<Note>> RetrieveNotes();
        
        Task<IEnumerable<Note>> QueryNotes(string query);
    }
}
