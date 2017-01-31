using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StackExchange.Redis;

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
