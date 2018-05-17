using Ip.Sdk.Commons.Enumerations;
using Ip.Sdk.Commons.Extensions;
using Ip.Sdk.ErrorHandling.CustomExceptions;
using Ip.Sdk.Security.AuthObjects;
using Ip.Sdk.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ip.Sdk.Security.Api.Models
{
    public class IpUser : IIpUser
    {
        private IList<IIpRole> _roles;
        private IList<IIpClaim> _claims;
        private IList<IIpSecurityQuestion> _securityQuestions;

        /// <summary>
        /// A Guid to represent the user's identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// A Guid for password resets to handle reset requests
        /// </summary>
        public Guid PasswordResetToken { get; set; }

        /// <summary>
        /// Username is a unique field that identifies a user
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Email address for the user
        /// </summary>
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// PasswordHash is the secret to authenticate the user
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// The Salt for the user's password
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// The number of iterations for a slow authentication algorithm
        /// </summary>
        public int Iterations { get; set; }

        /// <summary>
        /// How many consecutive failed login attempts
        /// </summary>
        public int ConsecutiveFailedAttempts { get; set; }

        /// <summary>
        /// Has the user confirmed their account
        /// </summary>
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// Is the user currently logged in
        /// </summary>
        public bool IsLoggedIn { get; set; }

        /// <summary>
        /// Is the user an active user
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is the user locked out
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// The date the user was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date the user was last updated, null if never
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// The date the user last logged in, null if never
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// The two factor destination object
        /// </summary>
        public BaseTwoFactorDestination TwoFactorDestination { get; set; }

        /// <summary>
        /// The security policy applied to the user
        /// </summary>
        public IIpSecurityPolicy UserSecurityPolicy { get; set; }

        /// <summary>
        /// The roles a user belongs to
        /// </summary>
        public IList<IIpRole> Roles
        {
            get { return _roles = (_roles ?? new List<IIpRole>()); }
            set { _roles = value; }
        }

        /// <summary>
        /// The claims a user has
        /// </summary>
        public IList<IIpClaim> Claims
        {
            get { return _claims = (_claims ?? new List<IIpClaim>()); }
            set { _claims = value; }
        }

        /// <summary>
        /// The security questions and answers the user used
        /// </summary>
        public IList<IIpSecurityQuestion> SecurityQuestions
        {
            get { return _securityQuestions = (_securityQuestions ?? new List<IIpSecurityQuestion>()); }
            set { _securityQuestions = value; }
        }

        /// <summary>
        /// Identifies if a user is in a role
        /// </summary>
        /// <param name="roleName">The name of the role to check. Roles are NOT case sensitive</param>
        /// <returns>True if in the role, false if not</returns>
        public bool IsInRole(string roleName)
        {
            return Roles.Any(r => r.RoleName.Equals(roleName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets a claim, if available
        /// </summary>
        /// <param name="claimKey">The claim key to return. Claims are NOT case sensitive</param>
        /// <returns>A claim based on the key</returns>
        public IIpClaim GetClaim(string claimKey)
        {
            return Claims.FirstOrDefault(c => c.ClaimKey.Equals(claimKey, StringComparison.OrdinalIgnoreCase));
        }

        //TODO: Finish Implementing all below

        /// <summary>
        /// Authenticates the users' password
        /// </summary>
        /// <param name="password">The password to authenticate</param>
        /// <returns>A response based on the authentication results</returns>
        public virtual IpResponse<AuthenticationStatus> Authenticate(string password)
        {
            return new IpResponse<AuthenticationStatus>();
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The IIpUser object to create</param>
        /// <returns>A response based on the creation</returns>
        public virtual IpResponse<IpUserEditStatus> Create(IIpUser user, string password, string confirmPassword)
        {
            var validPassword = ValidatePassword(password, confirmPassword);
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
        /// Updates an existing user
        /// </summary>
        /// <param name="user">The IIpUser object to update</param>
        /// <returns>A response based on the update</returns>
        public virtual IpResponse<IpUserEditStatus> Update(IIpUser user)
        {
            var validUser = ValidateUser(user);

            if (validUser != IpUserEditStatus.Success)
            {
                return new IpResponse<IpUserEditStatus> { Status = validUser, ResponseMessage = validUser.ToDescription() };
            }

            return new IpResponse<IpUserEditStatus>();
        }

        /// <summary>
        /// Deletes a user by their Id
        /// </summary>
        /// <param name="id">The Id of the user</param>
        /// <returns>A response based on the deletion</returns>
        public virtual IpResponse<IpUserEditStatus> Delete()
        {
            return new IpResponse<IpUserEditStatus>();
        }

        /// <summary>
        /// Changes a user's password
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the change of password</returns>
        public virtual IpResponse<PasswordEditStatus> ChangePassword(string password, string confirmPassword)
        {
            var validPassword = ValidatePassword(password, confirmPassword);

            if (validPassword != PasswordEditStatus.Success)
            {
                return new IpResponse<PasswordEditStatus> { Status = validPassword, ResponseMessage = validPassword.ToDescription() };
            }

            return new IpResponse<PasswordEditStatus>();
        }

        /// <summary>
        /// Triggers the reset password process
        /// </summary>
        /// <returns>A response based on the password reset</returns>
        public virtual IpResponse<PasswordEditStatus> ResetPassword()
        {
            return new IpResponse<PasswordEditStatus>();
        }

        /// <summary>
        /// Triggers the reset password process
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A response based on the password reset</returns>
        public virtual IpResponse<PasswordEditStatus> ResetPassword(string password, string confirmPassword)
        {
            var validPassword = ValidatePassword(password, confirmPassword);

            if (validPassword != PasswordEditStatus.Success)
            {
                return new IpResponse<PasswordEditStatus> { Status = validPassword, ResponseMessage = validPassword.ToDescription() };
            }

            return new IpResponse<PasswordEditStatus>();
        }

        /// <summary>
        /// Triggers the reset password process using security questions and answers
        /// </summary>
        /// <param name="securityAnswers">The security questions and answers collection</param>
        /// <returns>A response based on the password reset</returns>
        public virtual IpResponse<PasswordEditStatus> ResetPassword(IList<IIpSecurityQuestion> securityAnswers)
        {
            var validQuestions = ValidateSecurityQuestions(securityAnswers);

            if (validQuestions != PasswordEditStatus.Success)
            {
                return new IpResponse<PasswordEditStatus> { Status = validQuestions, ResponseMessage = validQuestions.ToDescription() };
            }

            return new IpResponse<PasswordEditStatus>();
        }

        /// <summary>
        /// Triggers the reset password process using security questions and answers
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <param name="securityAnswers">The security questions and answers collection</param>
        /// <returns>A response based on the password reset</returns>
        public virtual IpResponse<PasswordEditStatus> ResetPassword(string password, string confirmPassword, IList<IIpSecurityQuestion> securityAnswers)
        {
            var validPassword = ValidatePassword(password, confirmPassword);
            var validQuestions = ValidateSecurityQuestions(securityAnswers);

            if (validPassword != PasswordEditStatus.Success)
            {
                return new IpResponse<PasswordEditStatus> { Status = validPassword, ResponseMessage = validPassword.ToDescription() };
            }

            if (validQuestions != PasswordEditStatus.Success)
            {
                return new IpResponse<PasswordEditStatus> { Status = validQuestions, ResponseMessage = validQuestions.ToDescription() };
            }

            return new IpResponse<PasswordEditStatus>();
        }

        #region Helpers
        /// <summary>
        /// Validates that the password meets the criteria outlined in the User's Security Policy
        /// </summary>
        /// <param name="password">The password the user wants</param>
        /// <param name="confirmPassword">The confirmation of the password the user wants. This should match the password</param>
        /// <returns>A PasswordEditStatus indicating the result of the validation</returns>
        protected virtual PasswordEditStatus ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return PasswordEditStatus.PasswordMissing;
            }

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                return PasswordEditStatus.ConfirmPasswordMissing;
            }

            if (!password.Equals(confirmPassword))
            {
                return PasswordEditStatus.MismatchPassword;
            }

            if (password.Length < UserSecurityPolicy.MaximumPasswordLength || password.Length > UserSecurityPolicy.MaximumPasswordLength)
            {
                return PasswordEditStatus.PasswordInvalid;
            }

            if (!Regex.IsMatch(password, UserSecurityPolicy.PasswordComplexityRegex))
            {
                return PasswordEditStatus.PasswordInvalid;
            }

            return PasswordEditStatus.Success;
        }

        /// <summary>
        /// Validates that the security questions and answers match what the user has set
        /// </summary>
        /// <param name="securityAnswers">The questions and matching answers provided to compare against the user's data</param>
        /// <returns>A PasswordEditStatus indicating the result of the validation</returns>
        protected virtual PasswordEditStatus ValidateSecurityQuestions(IList<IIpSecurityQuestion> securityAnswers)
        {
            if (securityAnswers == null || !securityAnswers.Any())
            {
                return PasswordEditStatus.SecurityQuestionsMissing;
            }

            foreach (var sa in securityAnswers)
            {
                if (string.IsNullOrWhiteSpace(sa.Question) || string.IsNullOrWhiteSpace(sa.Answer))
                {
                    return PasswordEditStatus.SecurityQuestionsMissing;
                }

                if (!SecurityQuestions.Any(sq => sq.Question.Equals(sa.Question, StringComparison.OrdinalIgnoreCase)))
                {
                    return PasswordEditStatus.SecurityQuestionFailed;
                }

                try
                {
                    var question = SecurityQuestions.Single(sq => sq.Question.Equals(sa.Question, StringComparison.OrdinalIgnoreCase));

                    if (!question.Answer.Equals(sa.Answer, StringComparison.OrdinalIgnoreCase))
                    {
                        return PasswordEditStatus.SecurityQuestionFailed;
                    }
                }
                catch (Exception ex)
                {
                    throw new IpSecurityException("There was not exactly one matching Security Question assigned to the user", ex);
                }                
            }

            return PasswordEditStatus.Success;
        }

        protected virtual IpUserEditStatus ValidateUser(IIpUser user)
        {
            //TODO: Validate the email, username, etc...
            return IpUserEditStatus.Success;
        }
        #endregion
    }
}