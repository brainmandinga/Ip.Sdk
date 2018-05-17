namespace Ip.Sdk.Security.Interfaces
{
    /// <summary>
    /// Security Question Information
    /// </summary>
    public interface IIpSecurityQuestion
    {
        /// <summary>
        /// The question text
        /// </summary>
        string Question { get; set; }

        /// <summary>
        /// The answer used
        /// </summary>
        string Answer { get; set; }
    }
}
