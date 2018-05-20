using Ip.Sdk.Api.Models;
using Ip.Sdk.Security.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ip.Sdk.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class IpUserController : ApiController
    {
        private IIpUser _user;

        public IpUserController()
        {
            _user = new IpUser();
        }

        //TODO: Use custom response objects to return as well as custom IHttpActionResults
        //TODO: Create reusable helpers for validation
        //TODO: Finalize implementations

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register([FromBody] IIpUserCreate user)
        {
            var createUser = new IpUserCreate();

            //TODO: this should not only check for username, but also email
            var usr = await _user.GetByUsernameAsync(user.Username);

            if (usr != null)
            {
                return NotFound();
            }

            var result = await createUser.CreateAsync(user);

            return Ok();
        }

        [AllowAnonymous]
        [Route("resetpassword/{id:guid}/request")]
        [HttpPut]
        public async Task<IHttpActionResult> ResetPasswordRequest(Guid id)
        {
            var usr = await _user.GetByIdAsync(id);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.ResetPasswordAsync();

            return Ok();
        }

        [AllowAnonymous]
        [Route("resetpassword/{id:guid}/request/withquestions")]
        [HttpPut]
        public async Task<IHttpActionResult> ResetPasswordRequestWithQuestions(Guid id, [FromBody] IIpPasswordReset passwordDetails)
        {
            var usr = await _user.GetByIdAsync(id);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.ResetPasswordAsync(passwordDetails.SecurityQuestions);

            return Ok();
        }

        [AllowAnonymous]
        [Route("resetpassword/{id:guid}/change")]
        [HttpPut]
        public async Task<IHttpActionResult> ResetPasswordChange(Guid id, [FromBody] IIpPasswordReset passwordDetails)
        {
            var usr = await _user.GetByIdAsync(id);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.ResetPasswordAsync(passwordDetails.Password, passwordDetails.ConfirmPassword);

            return Ok();
        }

        [AllowAnonymous]
        [Route("resetpassword/{id:guid}/change/withquestions")]
        [HttpPut]
        public async Task<IHttpActionResult> ResetPasswordChangeWithQuestions(Guid id, [FromBody] IIpPasswordReset passwordDetails)
        {
            var usr = await _user.GetByIdAsync(id);

            if (usr == null)
            {
                return NotFound();
            }

            var result = usr.ResetPasswordAsync(passwordDetails.Password, passwordDetails.ConfirmPassword, passwordDetails.SecurityQuestions);

            return Ok();
        }

        [Authorize]
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] IIpUserCreate user)
        {
            var createUser = new IpUserCreate();

            //TODO: this should not only check for username, but also email
            var usr = await _user.GetByUsernameAsync(user.Username);

            if (usr != null)
            {
                return NotFound();
            }

            var result = await createUser.CreateAsync(user);

            return Ok();
        }

        [Authorize]
        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> Update([FromBody] IIpUser user)
        {
            var usr = await _user.GetByIdAsync(user.Id);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.UpdateAsync(user);

            return Ok();
        }

        [Authorize]
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteById(Guid id)
        {
            var usr = await _user.GetByIdAsync(id);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.DeleteAsync();

            return Ok();
        }

        [Authorize]
        [Route("{username}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteByUsername(string username)
        {
            var usr = await _user.GetByUsernameAsync(username);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.DeleteAsync();

            return Ok();
        }

        [Authorize]
        [Route("{email}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteByEmail(string email)
        {
            var usr = await _user.GetByEmailAddressAsync(email);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.DeleteAsync();

            return Ok();
        }

        [Authorize]
        [Route("changepassword/{id:guid}")]
        [HttpPut]
        public async Task<IHttpActionResult> ChangePassword(Guid id, [FromBody] IIpPasswordReset passwordDetails)
        {
            var usr = await _user.GetByIdAsync(id);

            if (usr == null)
            {
                return NotFound();
            }

            var result = await usr.ChangePasswordAsync(passwordDetails.Password, passwordDetails.ConfirmPassword);

            return Ok();
        }        
    }
}
