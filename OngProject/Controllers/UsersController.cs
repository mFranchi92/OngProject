using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.IAuth;

namespace OngProject.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = ("Admin"))]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAll();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.Delete(id);
            if (result.Succeeded)
                return Ok("Deleted successfully");
            else
                return NotFound(result);
        }
        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromForm] UserUpdateDto _user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.Update(_user, User);
                    if (result.IsSuccess)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                return BadRequest("Some properties are not valid");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }




        }
    }
}
