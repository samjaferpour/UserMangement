using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Contract.Dtos;
using UserManagement.Contract.Interfaces.Services;
using UserManagement.Utility;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRegisterService _userRegisterService;
        private readonly IUserLoginService _userLoginService;

        public AuthController(IUserRegisterService userRegisterService, IUserLoginService userLoginService)
        {
            this._userRegisterService = userRegisterService;
            this._userLoginService = userLoginService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var result = await _userRegisterService.Register(request);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Server side error");
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var result = await _userLoginService.Login(request);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Server side error");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RgenerateToken([FromBody] RgenerateTokenDto request)
        {
            var currentToken = await _context.Tokens.Where(t => t.RefreshToken == request.refreshToken).FirstOrDefaultAsync();
            if (currentToken == null)
            {
                return NotFound("Invalid refresh token");
            }
            else
            {
                var user = await _context.Users.Where(u => u.Uid == currentToken.UserUid).FirstOrDefaultAsync();
                if (user == null)
                {
                    return NotFound("User not found");
                }
                var token = GenerateToken.GetToken(user);

                currentToken.RefreshToken = token.RefreshToken;
                currentToken.RefreshTokenExpireTime = DateTime.Now.AddDays(1);
                await _context.SaveChangesAsync();

                return Ok(token);
            }
        }
    }
}
