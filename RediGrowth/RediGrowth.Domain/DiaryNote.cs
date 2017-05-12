using System;
using System.Collections.Generic;
using System.Text;

namespace RediGrowth.Domain
{
    class DiaryNote
    {
        public Guid DiaryEntryId { get; }
        public string Text { get; }
        public Guid Id { get; }

        public DiaryNote(Guid id, Guid diaryEntryId, string text)
        {
            Id = id;
            DiaryEntryId = diaryEntryId;
            Text = text;
        }
    }
}
