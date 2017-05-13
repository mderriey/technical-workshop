using System;
using Xunit;

namespace RediGrowth.Domain.Tests
{
    public class DiaryEntryTests
    {
        [Fact]
        public void WhenCallingAddNote_TheNoteIsAdded()
        {
            var entry = CreateTestEntry();

            var noteId = Guid.NewGuid();
            var noteText = "A super note";

            entry.AddNote(noteId, noteText);

            Assert.Contains(entry.Notes, x => x.Id == noteId && x.Text == noteText);
        }

        public void WhenCallingAddNoteWithAnExistingId_AnArgumentExceptionIsThrown()
        {
            var entry = CreateTestEntry();

            var noteId = Guid.NewGuid();
            var noteText = "A super note";
            entry.AddNote(noteId, noteText);

            var exception = Record.Exception(() => entry.AddNote(noteId, "Another super note"));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void WhenCallingChangeNoteAndNoteDoesntExist_AnArgumentExceptionIsThrown()
        {
            var entry = CreateTestEntry();

            var exception = Record.Exception(() => entry.ChangeNote(Guid.NewGuid(), "BOOM"));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void WhenCallingChangeNoteAndNoteExists_TextIsUpdated()
        {
            var entry = CreateTestEntry();

            var noteId = Guid.NewGuid();
            var noteText = "A super note";

            entry.AddNote(noteId, noteText);

            entry.ChangeNote(noteId, "A great note");

            Assert.Contains(entry.Notes, x => x.Id == noteId && x.Text == "A great note");
        }

        [Fact]
        public void WhenCallingDeleteNoteAndNoteDoesntExist_AnArgumentExceptionIsThrown()
        {
            var entry = CreateTestEntry();

            var exception = Record.Exception(() => entry.DeleteNote(Guid.NewGuid()));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void WhenCallingDeleteNoteAndNoteExists_NoteIsDeleted()
        {
            var entry = CreateTestEntry();

            var noteId = Guid.NewGuid();
            var noteText = "A super note";

            entry.AddNote(noteId, noteText);

            entry.DeleteNote(noteId);

            Assert.DoesNotContain(entry.Notes, x => x.Id == noteId);
        }

        [Fact]
        public void WhenCallingChangeRating_TheRatingIsUpdated()
        {
            var entry = CreateTestEntry();

            entry.ChangeRating(1);

            Assert.Equal(1, entry.Rating.Value);
        }

        private static DiaryEntry CreateTestEntry()
        {
            return new DiaryEntry(
                Guid.NewGuid(),
                DateTime.Today,
                Guid.NewGuid(),
                3);
        }
    }
}
