using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OngProject.Core.DTOs;
using OngProject.Core.Entities.AuthModel;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.IAuth;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Allow athentication functions
    /// Login, Register and Me(obtain logged in user data)
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUserService _userService;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthUserService userService, IMailService mailService, IConfiguration configuration)
        {
            _userService = userService;
            _mailService = mailService;
            _configuration = configuration;
        }

        /// <summary>
        /// Allows to register a user
        /// </summary>
        //api/auth/register
        [ProducesResponseType(typeof(UserManagerResponse), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserManagerResponse result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                {
                    await _mailService.SendMail(model.Email, _configuration["MailService:WelcomeMessage"], "Welcome");

                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        /// <summary>
        /// Allows to login a user
        /// </summary>
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        //api/auth/register
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserModel loginVM)
        {

            if (ModelState.IsValid)
            {
                UserManagerResponse result = await _userService.Login(loginVM);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {

                    return BadRequest(result);
                }
            }
            return BadRequest("Some properties are not valid");
        }

        /// <summary>
        /// Get authenticated user data
        /// </summary>
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(401)]
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult> Me()
        {
            UserDto result = _userService.MeAsync(User).Result;
            return Ok(result);
        }
    }
}
