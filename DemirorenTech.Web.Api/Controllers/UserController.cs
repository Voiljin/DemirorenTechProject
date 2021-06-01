using DemirorenTech.Business.Commons.Models.CommonModels;
using DemirorenTech.Business.Commons.Models.UserModels;
using DemirorenTech.Business.IEngines.IUserEngines;
using DemirorenTech.Web.Api.Core.Authorizations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemirorenTech.Web.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserEngine _userEngine;
        private IConfiguration _configuration;
        public UserController(IUserEngine userEngine, IConfiguration configuration)
        {
            _userEngine = userEngine;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login(RequestToken<UserAuthenticateRequest> request)
        {
            try
            {
                var result = _userEngine.Login(request.Filter.Username, request.Filter.Password);

                return Ok(Token<UserResponse>.Instance.Login(result, AuthorizationProvider.GenerateJSONWebToken(result, _configuration["Jwt:Key"], _configuration["Jwt:Issuer"])));
            }
            catch (Exception ex)
            {
                return Ok(Token<UserResponse>.Instance.FailResult("Login Error", ex.Message));
            }
        }

        [HttpPost("InsertUser")]
        public IActionResult InsertUser(RequestToken<InsertUserRequest> request)
        {
            var response = Token<UserResponse>.Instance;

            try
            {
                var insertUser = _userEngine.InsertUser(request.Filter);

                response.SuccessResult(insertUser);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("User Error", "Couldn't add user. Error Detail =>" + ex.Message));
            }
        }
    }
}
