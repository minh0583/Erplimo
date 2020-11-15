using System;
using System.Security.Claims;
using Erplimo.Auth.Infrastructure;
using Erplimo.Business.Services;
using Erplimo.Model.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Erplimo.Rest.Api.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public UserController(ILogger<UserController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        [AllowAnonymous]
        [HttpPost("getToken")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_userService.IsValidUserCredentials(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            var role = _userService.GetUserRole(request.UserName);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);

            _logger.LogInformation($"User [{request.UserName}] logged in the system.");

            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Role = role,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpGet("getCurrentUser")]
        [Authorize]
        public ActionResult GetCurrentUser()
        {
            return Ok(new LoginResult
            {
                UserName = User.Identity.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                OriginalUserName = User.FindFirst("OriginalUserName")?.Value
            });
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var userName = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);

            _logger.LogInformation($"User [{userName}] logged out the system.");
            return Ok();
        }

        [Authorize]
        [HttpPost("refreshToken")]
        public IActionResult Refresh()
        {
            return null;
        }
    }
}