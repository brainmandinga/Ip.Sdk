using Ip.Sdk.Commons.Validators.Interfaces;

namespace Ip.Sdk.Commons.Validators
{
    /// <summary>
    /// Class to handle range comparisons
    /// </summary>
    public abstract class IpRangeValidator<T> : IIpValidator
    {
        /// <summary>
        /// The value to compare
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The range start value
        /// </summary>
        public T RangeStart { get; set; }

        /// <summary>
        /// Are we being inclusive of the range start value
        /// </summary>
        public bool RangeStartInclusive { get; set; }

        /// <summary>
        /// The range end value
        /// </summary>
        public T RangeEnd { get; set; }

        /// <summary>
        /// Are we being inclusive of the range end value
        /// </summary>
        public bool RangeEndInclusive { get; set; }

        /// <summary>
        /// Overloaded constructor to initialize the values
        /// </summary>
        /// <param name="value">The value to compare</param>
        /// <param name="rangeStart">The start of the range</param>
        /// <param name="rangeStartInclusive">Do we include the start value in the comparison</param>
        /// <param name="rangeEnd">The end of the range</param>
        /// <param name="rangeEndInclusive">Do we include the end value in the comparison</param>
        protected IpRangeValidator(T value, T rangeStart, bool rangeStartInclusive, T rangeEnd, bool rangeEndInclusive)
        {
            Value = value;
            RangeStart = rangeStart;
            RangeStartInclusive = rangeStartInclusive;
            RangeEnd = rangeEnd;
            RangeEndInclusive = rangeEndInclusive;
        }

        /// <summary>
        /// Method to perform the validation on an implementation
        /// </summary>
        /// <returns></returns>
        public virtual IpValidationResult Validate()
        {
            if (RangeStartInclusive && RangeEndInclusive)
            {
                return CompareAllInclusive();
            }
            else if (RangeStartInclusive && !RangeEndInclusive)
            {
                return CompareStartInclusive();
            }
            else if (!RangeStartInclusive && RangeEndInclusive)
            {
                return CompareEndInclusive();
            }
            else
            {
                return CompareAllExclusive();
            }
        }

        /// <summary>
        /// Compare with start and end inclusive
        /// </summary>
        protected abstract IpValidationResult CompareAllInclusive();

        /// <summary>
        /// Compare with just the start being inclusive
        /// </summary>
        protected abstract IpValidationResult CompareStartInclusive();

        /// <summary>
        /// Compare with just the end inclusive
        /// </summary>
        protected abstract IpValidationResult CompareEndInclusive();

        /// <summary>
        /// Comapre with neither start nor end values included
        /// </summary>
        protected abstract IpValidationResult CompareAllExclusive();
    }
}
