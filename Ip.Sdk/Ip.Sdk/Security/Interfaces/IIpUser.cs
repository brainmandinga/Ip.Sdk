using Ip.Sdk.Security.AuthObjects;
using System;
using System.Collections.Generic;

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
        IDictionary<IIpSecurityQuestion, string> SecurityQuestions { get; set; }

        /// <summary>
        /// Identifies if a user is in a role
        /// </summary>
        /// <param name="roleName">The name of the role to check</param>
        /// <returns>True if in the role, false if not</returns>
        bool IsInRole(string roleName);

        /// <summary>
        /// Gets a claim, if available
        /// </summary>
        /// <param name="claimKey">The claim key to return</param>
        /// <returns>A claim based on the key</returns>
        IIpClaim GetClaim(string claimKey);

        /// <summary>
        /// Authenticates the users' password
        /// </summary>
        /// <param name="password">The password to authenticate</param>
        /// <returns>A response based on the authentication results</returns>
        AuthenticationResponse Authenticate(string password);
    }
}
