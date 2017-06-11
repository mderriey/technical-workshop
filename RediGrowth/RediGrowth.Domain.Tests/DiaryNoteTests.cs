using System;
using Xunit;

namespace RediGrowth.Domain.Tests
{
    public class DiaryNoteTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void WhenTextIsNullOrWhitespace_AnArgumentExceptionIsThrown(string text)
        {
            var exception = Record.Exception(() => new DiaryNote(Guid.NewGuid(), text));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void WhenTextIsNotNullOrWhitespace_NoExceptionIsThrown()
        {
            var exception = Record.Exception(() => new DiaryNote(Guid.NewGuid(), "A super note"));

            Assert.Null(exception);
        }

        [Fact]
        public void WhenPassingTextThroughCtor_TheTextIsReflected()
        {
            var note = new DiaryNote(Guid.NewGuid(), "A super note");

            Assert.Equal("A super note", note.Text);
        }

        [Fact]
        public void WhenCallingChangeNote_TheTextIsUpdated()
        {
            var note = new DiaryNote(Guid.NewGuid(), "A super note");
            note.ChangeText("A great note");

            Assert.Equal("A great note", note.Text);
        }
    }
}
