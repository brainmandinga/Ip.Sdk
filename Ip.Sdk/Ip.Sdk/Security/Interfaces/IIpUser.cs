using Ip.Sdk.Commons.Enumerations;
using Ip.Sdk.Security.AuthObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ip.Sdk.Security.Interfaces
{
    /// <summary>
    /// A basic user interface
    /// </summary>
    public interface IIpUser
    {
        /// <summary>
        /// A Guid to represent the user's identifier
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// A Guid for password resets to handle reset requests
        /// </summary>
        Guid PasswordResetToken { get; set; }

        /// <summary>
        /// Username is a unique field that identifies a user
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Email address for the user
        /// </summary>
        string EmailAddress { get; set; }

        /// <summary>
        /// PasswordHash is the secret to authenticate the user
        /// </summary>
        string PasswordHash { get; set; }

        /// <summary>
        /// The Salt for the user's password
        /// </summary>
        string PasswordSalt { get; set; }

        /// <summary>
        /// The number of iterations for a slow authentication algorithm
        /// </summary>
        int Iterations { get; set; }

        /// <summary>
        /// How many consecutive failed login attempts
        /// </summary>
        int ConsecutiveFailedAttempts { get; set; }        

        /// <summary>
        /// Has the user confirmed their account
        /// </summary>
        bool IsConfirmed { get; set; }

        /// <summary>
        /// Is the user currently logged in
        /// </summary>
        bool IsLoggedIn { get; set; }

        /// <summary>
        /// Is the user an active user
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Is the user locked out
        /// </summary>
        bool IsLocked { get; set; }               

        /// <summary>
        /// The date the user was created
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date the user was last updated, null if never
        /// </summary>
        DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// The date the user last logged in, null if never
        /// </summary>
        DateTime? LastLogin { get; set; }

        /// <summary>
        /// The two factor destination object
        /// </summary>
        BaseTwoFactorDestination TwoFactorDestination { get; set; }

        /// <summary>
        /// The security policy applied to the user
        /// </summary>
        IIpSecurityPolicy UserSecurityPolicy { get; set; }

        /// <summary>
        /// The roles a user belongs to
        /// </summary>
        IList<IIpRole> Roles { get; set; }

        /// <summary>
        /// The claims a user has
        /// </summary>
        IList<IIpClaim> Claims { get; set; }

        /// <summary>
        /// The security questions the user used
        /// </summary>
        IList<IIpSecurityQuestion> SecurityQuestions { get; set; }

        /// <summary>
        /// Identifies if a user is in a role
        /// </summary>
        /// <param name="roleName">The name of the role to check</param>
        /// <returns>True if in the role, false if not</returns>
        bool IsInRole(string roleName);

        /// <summary>
        /// Identifies if a user is in a role
        /// </summary>
        /// <param name="roleName">The name of the role to check</param>
        /// <returns>True if in the role, false if not</returns>
        Task<bool> IsInRoleAsync(string roleName);

        /// <summary>
        /// Gets a claim, if available
        /// </summary>
        /// <param name="claimKey">The claim key to return</param>
        /// <returns>A claim based on the key</returns>
        IIpClaim GetClaim(string claimKey);

        /// <summary>
        /// Gets a claim, if available
        /// </summary>
        /// <param name="claimKey">The claim key to return</param>
        /// <returns>A claim based on the key</returns>
        Task<IIpClaim> GetClaimAsync(string claimKey);

        /// <summary>
        /// Gets a user by their Id
        /// </summary>
        /// <param name="id">The Id to retrieve</param>
        /// <returns>An IIpUser object</returns>
        IIpUser GetById(Guid id);

        /// <summary>
        /// Gets a user by their Id
        /// </summary>
        /// <param name="id">The Id to retrieve</param>
        /// <returns>An IIpUser object</returns>
        Task<IIpUser> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets a user by their username
        /// </summary>
        /// <param name="username">The username to retrieve</param>
        /// <returns>An IIpUser object</returns>
        IIpUser GetByUsername(string username);

        /// <summary>
        /// Gets a user by their username
        /// </summary>
        /// <param name="username">The username to retrieve</param>
        /// <returns>An IIpUser object</returns>
        Task<IIpUser> GetByUsernameAsync(string username);

        /// <summary>
        /// Gets a user by their email address
        /// </summary>
        /// <param name="email">The email address to retrieve</param>
        /// <returns>An IIpUser object</returns>
        IIpUser GetByEmailAddress(string email);

        /// <summary>
        /// Gets a user by their email address
        /// </summary>
        /// <param name="email">The email address to retrieve</param>
        /// <returns>An IIpUser object</returns>
        Task<IIpUser> GetByEmailAddressAsync(string email);

        /// <summary>
        /// Authenticates the users' password
        /// </summary>
        /// <param name="password">The password to authenticate</param>
        /// <returns>A response based on the authentication results</returns>
        IpResponse<AuthenticationStatus> Authenticate(string password);

        /// <summary>
        /// Authenticates the users' password
        /// </summary>
        /// <param name="password">The password to authenticate</param>
        /// <returns>A response based on the authentication results</returns>
        Task<IpResponse<AuthenticationStatus>> AuthenticateAsync(string password);

        /// <summary>
        /// Authenticates the users' password
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password to authenticate</param>
        /// <returns>A response based on the authentication results</returns>
        IpResponse<AuthenticationStatus> Authenticate(string username, string password);

        /// <summary>
        /// Authenticates the users' password
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password to authenticate</param>
        /// <returns>A response based on the authentication results</returns>
        Task<IpResponse<AuthenticationStatus>> AuthenticateAsync(string username, string password);

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user">The IIpUser object to update</param>
        /// <returns>A response based on the update</returns>
        IpResponse<IpUserEditStatus> Update(IIpUser user);

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user">The IIpUser object to update</param>
        /// <returns>A response based on the update</returns>
        Task<IpResponse<IpUserEditStatus>> UpdateAsync(IIpUser user);

        /// <summary>
        /// Deletes a user by their Id
        /// </summary>
        /// <returns>A response based on the deletion</returns>
        IpResponse<IpUserEditStatus> Delete();

        /// <summary>
        /// Deletes a user by their Id
        /// </summary>
        /// <returns>A response based on the deletion</returns>
        Task<IpResponse<IpUserEditStatus>> DeleteAsync();

        /// <summary>
        /// Changes a user's password
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the change of password</returns>
        IpResponse<PasswordEditStatus> ChangePassword(string password, string confirmPassword);

        /// <summary>
        /// Changes a user's password
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the change of password</returns>
        Task<IpResponse<PasswordEditStatus>> ChangePasswordAsync(string password, string confirmPassword);

        /// <summary>
        /// Triggers the reset password process
        /// </summary>
        /// <returns>A response based on the password reset</returns>
        IpResponse<PasswordEditStatus> ResetPassword();

        /// <summary>
        /// Triggers the reset password process
        /// </summary>
        /// <returns>A response based on the password reset</returns>
        Task<IpResponse<PasswordEditStatus>> ResetPasswordAsync();

        /// <summary>
        /// Triggers the reset password process
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the password reset</returns>
        IpResponse<PasswordEditStatus> ResetPassword(string password, string confirmPassword);

        /// <summary>
        /// Triggers the reset password process
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the password reset</returns>
        Task<IpResponse<PasswordEditStatus>> ResetPasswordAsync(string password, string confirmPassword);

        /// <summary>
        /// Triggers the reset password process using security questions and answers
        /// </summary>
        /// <param name="securityAnswers">The security questions and answers collection</param>
        /// <returns>A response based on the password reset</returns>
        IpResponse<PasswordEditStatus> ResetPassword(IList<IIpSecurityQuestion> securityAnswers);

        /// <summary>
        /// Triggers the reset password process using security questions and answers
        /// </summary>
        /// <param name="securityAnswers">The security questions and answers collection</param>
        /// <returns>A response based on the password reset</returns>
        Task<IpResponse<PasswordEditStatus>> ResetPasswordAsync(IList<IIpSecurityQuestion> securityAnswers);

        /// <summary>
        /// Triggers the reset password process using security questions and answers
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <param name="securityAnswers">The security questions and answers collection</param>
        /// <returns>A response based on the password reset</returns>
        IpResponse<PasswordEditStatus> ResetPassword(string password, string confirmPassword, IList<IIpSecurityQuestion> securityAnswers);

        /// <summary>
        /// Triggers the reset password process using security questions and answers
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <param name="securityAnswers">The security questions and answers collection</param>
        /// <returns>A response based on the password reset</returns>
        Task<IpResponse<PasswordEditStatus>> ResetPasswordAsync(string password, string confirmPassword, IList<IIpSecurityQuestion> securityAnswers);
    }
}
