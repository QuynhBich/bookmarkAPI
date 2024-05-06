using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookmarkWeb.API.Commons;
using BookmarkWeb.API.Commons.Enums;
using BookmarkWeb.API.Models.Common.Schemas;
using BookmarkWeb.API.Models.Login;
using BookmarkWeb.API.Models.Login.Schemas;
using Microsoft.AspNetCore.Mvc;

namespace BookmarkWeb.API.Controllers
{
    [Route("auth")]
    public class LoginController: ControllerBase
    {
        private readonly ILoginModel _loginModel;

        public LoginController(
            ILoginModel loginModel
        )
        {
            _loginModel = loginModel ?? throw new ArgumentNullException(nameof(loginModel));
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckAccount([FromBody] UserLogin user)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = await _loginModel.CheckAccount(user);
                }
                else
                {
                    response.Code = CodeResponse.NOT_VALIDATE;
                }
            }
            catch (Exception e)
            {
                response.Code = CodeResponse.SERVER_ERROR;
                response.MsgNo = MSG_NO.SERVER_ERROR;
                response.Data.Add("error", e.Message);
            }
            return Ok(response);
        }

        [HttpPost("login/refresh-token")]
        [ProducesResponseType(typeof(ResponseInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RefreshToken([FromBody] Token token)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = await _loginModel.RefreshToken(token);
                if (response == null)
                {
                    return Forbid();
                }
            }
            catch (Exception e)
            {

                response.Code = CodeResponse.SERVER_ERROR;
                response.MsgNo = MSG_NO.SERVER_ERROR;
                response.Data.Add("error", e.Message);
            }
            return Ok(response);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterAccount(UserDto user)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = await _loginModel.RegisterAccount(user);
                }
                else
                {
                    response.Code = CodeResponse.NOT_VALIDATE;
                }
            }
            catch (Exception e)
            {
                response.Code = CodeResponse.SERVER_ERROR;
                response.MsgNo = MSG_NO.SERVER_ERROR;
                response.Data.Add("error", e.Message);
            }
            return Ok(response);
        }

        [HttpGet("logout")]
        [ProducesResponseType(typeof(ResponseInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Logout()
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = await _loginModel.RemoveToken();
            }
            catch (Exception e)
            {
                response.Code = CodeResponse.SERVER_ERROR;
                response.MsgNo = MSG_NO.SERVER_ERROR;
                response.Data.Add("error", e.Message);
            }
            return Ok(response);
        }

        [HttpPost("google")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleOAuthCode param)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                response = await _loginModel.GetGoogleUserTokenAsync(param.OAuthCode);
            }
            catch (Exception e)
            {
                response.Code = CodeResponse.SERVER_ERROR;
                response.MsgNo = MSG_NO.SERVER_ERROR;
                response.Data.Add("error", e.Message);
            }
            return Ok(response);
        }
    }
}