using System;
using System.Collections.Generic;

namespace RediGrowth.Domain
{
    public class DiaryEntry
    {
        public Guid Id { get; }
        public DateTime Date { get; }
        public Guid PersonId { get; }

        public IEnumerable<DiaryNote> Notes => _notes;

        private List<DiaryNote> _notes;

        public DiaryEntry(Guid id, DateTime date, Guid personId)
        {
            PersonId = personId;
            Id = id;
            Date = date;
        }
    }
}
