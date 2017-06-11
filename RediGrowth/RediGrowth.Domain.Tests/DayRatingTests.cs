using System;
using Xunit;

namespace RediGrowth.Domain.Tests
{
    public class DayRatingTests
    {
        [Fact]
        public void WhenRatingIsWithinOneToFive_NoExceptionIsThrown()
        {
            var exception = Record.Exception(() => new DayRating(2));

            Assert.Null(exception);
        }

        [Fact]
        public void WhenPassingRatingThroughCtor_TheValueIsReflected()
        {
            var rating = new DayRating(3);

            Assert.Equal(3, rating.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void WhenRatingIsNotWithinOneToFive_AnArgumentExceptionIsThrown(int rating)
        {
            var exception = Record.Exception(() => new DayRating(rating));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }

        public static TheoryData<DayRating, DayRating, bool> Ratings
        {
            get
            {
                return new TheoryData<DayRating, DayRating, bool>
                {
                    { new DayRating(2), new DayRating(2), true },
                    { new DayRating(2), new DayRating(3), false },
                    { null, new DayRating(3), false },
                    { new DayRating(3), null, false }
                };
            }
        }

        [Theory]
        [MemberData(nameof(Ratings))]
        public void WhenRatingsAreEqual_TheInstancesAreEqual(DayRating a, DayRating b, bool expectedOutcome)
        {
            var result = a == b;

            Assert.Equal(expectedOutcome, result);
        }
    }
}
