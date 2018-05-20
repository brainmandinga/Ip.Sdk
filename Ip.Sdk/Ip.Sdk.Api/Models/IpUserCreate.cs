using Ip.Sdk.Api.Enumerations;
using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.Security.AuthObjects;
using Ip.Sdk.Security.Interfaces;
using System.Threading.Tasks;

namespace Ip.Sdk.Api.Models
{
    /// <summary>
    /// User create object
    /// </summary>
    public class IpUserCreate: IpUser, IIpUserCreate
    {
        /// <summary>
        /// The password for creation
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The confirm password for creation
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The IIpUser object to create</param>
        /// <returns>A response based on the creation</returns>
        public virtual IIpResponse Create(IIpUserCreate user)
        {
            var validPassword = ValidatePassword(user.Password, user.ConfirmPassword);
            var validUser = ValidateUser(user);

            if (validPassword != PasswordEditStatus.Success)
            {
                return new IpResponse { Status = (int)IpUserEditStatus.PasswordInvalid, ResponseMessage = validPassword.ToDescription() };
            }

            if (validUser != IpUserEditStatus.Success)
            {
                return new IpResponse { Status = (int)validUser, ResponseMessage = validUser.ToDescription() };
            }

            return new IpResponse();
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The IIpUser object to create</param>
        /// <returns>A response based on the creation</returns>
        public async virtual Task<IIpResponse> CreateAsync(IIpUserCreate user)
        {
            return await Task.Run(() => Create(user));
        }
    }
}