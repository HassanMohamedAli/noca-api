using ArticleManagement.Application.Common;
using ArticleManagement.Application.DTOs;
using ArticleManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagement.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse<string>(null, "Invalid credentials", false));
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse<string>(null, "Invalid credentials", false));
            }
            var token = _jwtTokenGenerator.GenerateToken(user);
            return Ok(new ApiResponse<string>(token, "Login successful", true));
        }




    }
}
