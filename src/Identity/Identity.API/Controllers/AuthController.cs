using Identity.API.Models;
using Identity.API.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalBrand.Domain.Entities.DTOs;
using PersonalBrand.Domain.Entities.Models;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AuthController(IConfiguration configuration, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Register(Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Invalid model state",
                    StatusCode = 400
                });
            }

            var existingUser = await _userManager.FindByEmailAsync(register.Email);

            if (existingUser != null)
            {
                return BadRequest(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "This email is already registred!",
                    StatusCode = 400,
                });
            }

            var user = new UserModel()
            {
                UserName = register.UserName,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Failed to create user",
                    StatusCode = 400,

                });
            }

            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new ResponseModel()
            {
                IsSuccess = true,
                Message = "User created successfully",
                StatusCode = 201
            });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Models.Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Token()
                {
                    Message = "Invalid model state",
                    isSuccess = false,
                    token = ""
                });
            }
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest(new Token()
                {
                    Message = "Email not found",
                    isSuccess = false,
                    token = ""
                });
            }

            var checker = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checker)
            {
                return BadRequest(new Token()
                {
                    Message = "Incorrect password",
                    isSuccess = false,
                    token = ""
                });
            }

            var token = user.GenerateToken(_configuration, _userManager).Result;

            return Ok(new Token()
            {
                token = token,
                isSuccess = true,
                Message = $"Login successfully! Your id is {user.Id}"
            });
        }

        [HttpPost("ExternalLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLogin(ExternalLogin model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                user = new UserModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhotoUrl = model.PhotoUrl,
                };

                var res = await _userManager.CreateAsync(user);

                var result = await _userManager.AddToRoleAsync(user, "User");
            }

            var info = new UserLoginInfo(model.Provider, model.ProviderKey, user.UserName);

            await _userManager.AddLoginAsync(user, info);

            await _signInManager.SignInAsync(user, false);

            var token = user.GenerateToken(_configuration, _userManager).Result;

            return Ok(new Token()
            {
                token = token,
                isSuccess = true,
                Message = "Success"
            });
        }
    }
}
