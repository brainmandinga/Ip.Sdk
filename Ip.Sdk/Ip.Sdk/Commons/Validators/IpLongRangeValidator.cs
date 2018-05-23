namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Validates a long against a range
    /// </summary>
    public class IpLongRangeValidator : IpRangeValidator<long>
    {
        /// <summary>
        /// Overloaded constructor to initialize the values
        /// </summary>
        /// <param name="value">The value to compare</param>
        /// <param name="rangeStart">The start of the range</param>
        /// <param name="rangeStartInclusive">Do we include the start value in the comparison</param>
        /// <param name="rangeEnd">The end of the range</param>
        /// <param name="rangeEndInclusive">Do we include the end value in the comparison</param>
        public IpLongRangeValidator(long value, long rangeStart, bool rangeStartInclusive, long rangeEnd, bool rangeEndInclusive)
            : base(value, rangeStart, rangeStartInclusive, rangeEnd, rangeEndInclusive) { }

        /// <summary>
        /// Compare with start and end inclusive
        /// </summary>
        protected override IpValidationResult CompareAllInclusive()
        {
            var retVal = new IpValidationResult();

            if (Value >= RangeStart && Value <= RangeEnd)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The compared value is not in the inclusive range";

            return retVal;
        }

        /// <summary>
        /// Compare with just the start being inclusive
        /// </summary>
        protected override IpValidationResult CompareStartInclusive()
        {
            var retVal = new IpValidationResult();

            if (Value >= RangeStart && Value < RangeEnd)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The compared value is not in the range inclusive of the start";

            return retVal;
        }

        /// <summary>
        /// Compare with just the end inclusive
        /// </summary>
        protected override IpValidationResult CompareEndInclusive()
        {
            var retVal = new IpValidationResult();

            if (Value > RangeStart && Value <= RangeEnd)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The compared value is not in the range inclusive of the end";

            return retVal;
        }

        /// <summary>
        /// Comapre with neither start nor end values included
        /// </summary>
        protected override IpValidationResult CompareAllExclusive()
        {
            var retVal = new IpValidationResult();

            if (Value > RangeStart && Value < RangeEnd)
            {
                return retVal;
            }

            retVal.IsValid = false;
            retVal.ValidationMessage = "The compared value is not in the range excluding the start and end";

            return retVal;
        }
    }
}
