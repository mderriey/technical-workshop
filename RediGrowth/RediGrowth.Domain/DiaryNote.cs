using System;

namespace RediGrowth.Domain
{
    public class DiaryNote
    {
        public Guid DiaryEntryId { get; }
        public string Text { get; private set; }
        public Guid Id { get; } = Guid.NewGuid();

        public DiaryNote(Guid diaryEntryId, string text)
        {
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
