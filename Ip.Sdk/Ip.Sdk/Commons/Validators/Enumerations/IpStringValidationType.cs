namespace Ip.Sdk.Commons.Validators.Enumerations
{
    /// <summary>
    /// Enumerator for identifying the type of string comparison to do
    /// </summary>
    public enum IpStringValidationType
    {
        /// <summary>
        /// Starts with comparison
        /// </summary>
        StartsWith,

        /// <summary>
        /// Ends with comparison
        /// </summary>
        EndsWith,

        /// <summary>
        /// Contains comparison
        /// </summary>
        Contains,

        /// <summary>
        /// Equality comparison
        /// </summary>
        Equality
    }
}
