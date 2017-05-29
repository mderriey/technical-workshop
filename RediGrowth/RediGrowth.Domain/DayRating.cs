using System;

namespace RediGrowth.Domain
{
    public class DayRating
    {
        public int Value { get; }

        public DayRating(int rating)
        {
            CheckIsInRange(rating);
            this.Value = rating;
        }

        private void CheckIsInRange(int rating)
        {
            if (1 <= rating && rating <= 5)
            {
                return;
            }

            throw new ArgumentOutOfRangeException("Rating should be in 1 to 5 range", nameof(rating));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DayRating);
        }

        public bool Equals(DayRating rating)
        {
            if (rating == null)
            {
                return false;
            }
            return Value == rating.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(DayRating a, DayRating b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return Equals(a, b);
        }

        public static bool operator !=(DayRating a, DayRating b)
        {
            return !(a == b);
        }
    }
}
