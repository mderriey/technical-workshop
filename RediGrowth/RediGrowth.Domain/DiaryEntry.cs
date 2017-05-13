using System;
using System.Collections.Generic;
using System.Linq;

namespace RediGrowth.Domain
{
    public class DiaryEntry
    {
        public Guid Id { get; }
        public DateTime Date { get; }
        public Guid PersonId { get; }

        // Q: Should `DiaryEntry` expose the `Value` property of the Rating publicly
        // instead of the whole `DayRating` instance?
        public DayRating Rating { get; private set; }

        public IEnumerable<DiaryNote> Notes => _notes;

        private List<DiaryNote> _notes;

        public DiaryEntry(Guid id, DateTime date, Guid personId, int rating)
        {
            PersonId = personId;
            Id = id;
            Date = date;
            ChangeRating(rating);
            _notes = new List<DiaryNote>();
        }

        public void AddNote(Guid noteId, string text)
        {
            if (_notes.Any(x => x.Id == noteId))
            {
                throw new ArgumentNullException(nameof(noteId), $"A note with the id {noteId} already exists.");
            }

            _notes.Add(new DiaryNote(noteId, this.Id, text));
        }

        public void ChangeNote(Guid noteId, string text)
        {
            // Q: Should we have thie method in Note with class with validation? Idea is that notes can be modified only through DiaryEntry aggregate
            FindNoteById(noteId).ChangeText(text);
        }

        public void DeleteNote(Guid noteId)
        {
            _notes.Remove(FindNoteById(noteId));
        }

        private DiaryNote FindNoteById(Guid noteId)
        {
            var note = _notes.FirstOrDefault(n => n.Id == noteId);
            if (note == null)
            {
                throw new ArgumentException($"Note with id {noteId} not found", nameof(noteId));
            }
            return note;
        }

        public void ChangeRating(int newRating)
        {
            this.Rating = new DayRating(newRating);
        }
    }
}
