using Ip.Sdk.Commons.Enumerations;
using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.Security.AuthObjects;
using Ip.Sdk.Security.Interfaces;
using System.Threading.Tasks;

namespace Ip.Sdk.Security.Api.Models
{
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
        public virtual IpResponse<IpUserEditStatus> Create(IIpUserCreate user)
        {
            var validPassword = ValidatePassword(user.Password, user.ConfirmPassword);
            var validUser = ValidateUser(user);

            if (validPassword != PasswordEditStatus.Success)
            {
                return new IpResponse<IpUserEditStatus> { Status = IpUserEditStatus.PasswordInvalid, ResponseMessage = validPassword.ToDescription() };
            }

            if (validUser != IpUserEditStatus.Success)
            {
                return new IpResponse<IpUserEditStatus> { Status = validUser, ResponseMessage = validUser.ToDescription() };
            }

            return new IpResponse<IpUserEditStatus>();
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The IIpUser object to create</param>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the creation</returns>
        public async virtual Task<IpResponse<IpUserEditStatus>> CreateAsync(IIpUserCreate user)
        {
            return await Task.Run(() => Create(user));
        }
    }
}