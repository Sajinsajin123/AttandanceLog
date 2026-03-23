using AttandanceTracker.Application.Dto;
using AttandanceTracker.Application.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttandanceTracke.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }
        //[HttpGet("public")]
        [HttpPost("login")]
        //[Authorize]
        //[HttpGet("secure")]
        //[AllowAnonymous]//Allow specific API without token
        //[HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            try
            {
                var token = authService.Login(dto.Username, dto.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
