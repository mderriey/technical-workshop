using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RediGrowth.Api.Models;
using RediGrowth.Domain;

namespace RediGrowth.Api.Controllers
{
    [Route("api/diaryentries")]
    public class DiaryEntriesController: Controller
    {
        private static List<DiaryEntry> _entries = new List<DiaryEntry>()
        {
            new DiaryEntry(Guid.NewGuid(), DateTime.Today, Guid.NewGuid(), 3),
            new DiaryEntry(Guid.NewGuid(), DateTime.Today, Guid.NewGuid(), 4),
            new DiaryEntry(Guid.NewGuid(), DateTime.Today, Guid.NewGuid(), 2)
        };

        [HttpGet]
        [Route("")]
        public IEnumerable<DiaryEntry> GetAll()
        {
            return _entries; 
        }

        [HttpGet]
        [Route("{id:guid}")]
        public ActionResult Get(Guid id)
        {
            var entry = _entries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Add([FromBody]AddDiaryEntryViewModel entry)
        {
            if (_entries.Any(n => n.Id == entry.Id))
            {
                return BadRequest($"An entry with {entry.Id} id already exists");
            }
            var e = new DiaryEntry(entry.Id, entry.Date, entry.PersonId, entry.Rating);
            entry.Notes.ForEach(n => e.AddNote(n.Id, n.Text));
            _entries.Add(e);
            return Created(Url.Action(nameof(this.Get), new { id = e.Id }), null);
        }

    }
}
