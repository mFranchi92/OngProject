using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OngProject.Controllers
{
    [Authorize(Roles = ("Admin"))]
    [Route("[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        private readonly ISlideService _slideService;
        public SlidesController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        // GET: /<SlidesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var slidesDtoList = await _slideService.GetAllSlides();

            return Ok(slidesDtoList);
        }

        // GET /<SlidesController>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlide(int id)
        {
            var slide = await _slideService.GetSlideById(id);
            if (slide == null)
                return NotFound();

            return Ok(slide);
        }

        // POST /<SlidesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SlideCreateDto slideCreateDto)
        {   
            try
            {
                await _slideService.InsertSlide(slideCreateDto);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT /<SlidesController>/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SlideCreateDto slideCreateDto)
        {
            try
            {
                var result = await _slideService.UpdateSlide(id, slideCreateDto);
                if (result)
                    return Ok();

                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }

        }

        // DELETE /<SlidesController>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            if (!_slideService.EntityExists(id))
            {
                return NotFound();
            }
            await _slideService.DeleteSlide(id);
            return Ok();
        }

    }
}
