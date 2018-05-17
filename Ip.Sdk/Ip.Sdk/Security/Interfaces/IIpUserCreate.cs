using Ip.Sdk.Commons.Enumerations;
using Ip.Sdk.Security.AuthObjects;
using System.Threading.Tasks;

namespace Ip.Sdk.Security.Interfaces
{
    public interface IIpUserCreate : IIpUser
    {
        /// <summary>
        /// The password for creation
        /// </summary>
        string Password { get; set; }
        
        /// <summary>
        /// The confirm password for creation
        /// </summary>
        string ConfirmPassword { get; set; }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The IIpUser object to create</param>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the creation</returns>
        IpResponse<IpUserEditStatus> Create(IIpUserCreate user);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The IIpUser object to create</param>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the creation</returns>
        Task<IpResponse<IpUserEditStatus>> CreateAsync(IIpUserCreate user);
    }
}
