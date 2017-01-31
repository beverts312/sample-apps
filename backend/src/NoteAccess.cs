using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StackExchange.Redis;

using WebAPIApplication.Models;
using WebAPIApplication.Interfaces;

namespace WebAPIApplication
{
    public class NoteAccess : INoteAccess
    {
        private ConnectionMultiplexer redis;
        private IDatabase db;
        private IServer server;
        private string indexKey = "nextIndex";
        private string notesPrefix = "notes_";
        private string redisUrl = "redis-19531.c8.us-east-1-4.ec2.cloud.redislabs.com";
        private int redisPort = 19531;

        public NoteAccess()
        {
            UpdateConfig();
            InitializeDb().Wait();
        }

        public async Task<Note> AddNote(string note)
        {
            var index = (await db.StringGetAsync(indexKey)).ToString();
            var nextIndex = BuildNextIndex(index);
            await db.StringSetAsync(index, note);
            await db.StringSetAsync(indexKey, nextIndex);
            return new Note()
            {
                id = ParseIndex(index),
                body = note
            };
        }

        public async Task<Note> RetrieveNote(string id)
        {
            return await RetrieveNoteRaw(BuildIndex(id));
        }

        public async Task<IEnumerable<Note>> RetrieveNotes()
        {
            var noteIds = server.Keys(pattern: notesPrefix + "*");
            var tasks = noteIds.Select(id => RetrieveNoteRaw(id.ToString())).ToList();
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<Note>> QueryNotes(string query)
        {
            var notes = await RetrieveNotes();
            return notes.Where(n => n.body.Contains(query));
        }

        private void UpdateConfig()
        {
            var url = Environment.GetEnvironmentVariable("REDIS_URL");
            var port = Environment.GetEnvironmentVariable("REDIS_PORT");
            if (!String.IsNullOrEmpty(url))
            {
                redisUrl = url;
            }
            if (!String.IsNullOrEmpty(port))
            {
                redisPort = Convert.ToInt32(port);
            }
        }
        private async Task InitializeDb()
        {
            var dns = await Dns.GetHostAddressesAsync(redisUrl);
            var redisIp = dns.First().MapToIPv4().ToString();
            var connectionString = String.Format("{0}:{1}", redisIp, redisPort);
            redis = await ConnectionMultiplexer.ConnectAsync(connectionString);
            db = redis.GetDatabase();
            server = redis.GetServer(redisIp, redisPort);
            var index = await db.StringGetAsync(indexKey);
            if (index.IsNullOrEmpty)
            {
                await db.StringSetAsync(indexKey, BuildIndex("1"));
            }
        }


        private async Task<Note> RetrieveNoteRaw(string id)
        {
            var body = await db.StringGetAsync(id);
            return new Note()
            {
                id = ParseIndex(id),
                body = body.ToString()
            };
        }

        private string BuildIndex(string id)
        {
            return String.Concat(notesPrefix, id);
        }

        private string BuildNextIndex(string currentIndex)
        {
            var currentInt = ParseIndex(currentIndex);
            currentInt++;
            return String.Concat(notesPrefix, currentInt);
        }

        private int ParseIndex(string index)
        {
            return Convert.ToInt32(index.Substring(6));
        }
    }
}
