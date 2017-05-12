using System;
using System.Collections.Generic;
using System.Text;

namespace RediGrowth.Domain
{
    public class DayRating
    {
        public int Value { get; }

        public DayRating(int rating)
        {
            if (!IsInRange(rating))
            {
                throw new ArgumentException("Rating should be in 1 to 5 range", nameof(rating));
            }
            this.Value = rating;
        }

        private bool IsInRange(int rating)
        {
            return rating >= 1 && rating <= 5;
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
    }
}
