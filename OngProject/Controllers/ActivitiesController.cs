using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {

        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public IActionResult Insert([FromForm] ActivityInsertDto activity)
        {

            if (ModelState.IsValid)
            {
                var result = _activityService.InsertActivity(activity);

                if (result.Result.IsSuccess)
                {
                    return Ok(result.Result.Message);
                }
                else
                {
                    return BadRequest(result.Result.Message);
                }
            }
            return BadRequest("Some properties are not valid");
        }


      



       [Authorize(Roles = ("Admin"))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromForm] ActivityUpdateDto activityUpdateDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _activityService.UpdateActivity(id, activityUpdateDto);
                    if (result)
                    {
                        return Ok();
                    }
                    return NotFound();
                }
                return BadRequest("Some properties are not valid");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
