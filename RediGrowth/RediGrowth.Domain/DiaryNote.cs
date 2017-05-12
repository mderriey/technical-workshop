using System;
using System.Collections.Generic;
using System.Text;

namespace RediGrowth.Domain
{
    public class DiaryNote
    {
        public Guid DiaryEntryId { get; }
        public string Text { get; private set; }
        public Guid Id { get; }

        public DiaryNote(Guid id, Guid diaryEntryId, string text)
        {
            Id = id;
            DiaryEntryId = diaryEntryId;
            ChangeText(text);
        }

        public void ChangeText(string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
            {
                throw new ArgumentException("Should not be null or whitespace", nameof(newText));
            }
            Text = newText;
        }
    }
}
