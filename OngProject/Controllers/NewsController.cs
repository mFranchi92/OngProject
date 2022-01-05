using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
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
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET News
        /// <summary>
        /// Get all News.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        [HttpGet(Name = "GetNewsPage")]
        public async Task<IActionResult> GetPage(int page, int pageSize, string controller)
        {
            var news = await _newsService.GetAllNews(page, pageSize, Url.RouteUrl(nameof(GetPage)));
            return Ok(news);
        }

        // GET News/:id
        /// <summary>
        /// Get a news by id.
        /// </summary>
        /// <param name="id">A integer number.</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneNews(int id)
        {
           var onenews = await _newsService.GetNewsById(id);
            if (onenews != null)
                return Ok(onenews);
            return NotFound();
        }

        // POST News
        /// <summary>
        /// Create a News.
        /// </summary>
        /// <param name="newsDto">A type NewsDto object.</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] NewsDto newsDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _newsService.InsertNews(newsDto);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT News/:id
        /// <summary>
        /// Update a News specified by id.
        /// </summary>
        /// <param name="id">A integer number.</param>
        /// <param name="newsDto">A type NewsDto object.</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] NewsUpdateDto newsDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _newsService.UpdateNews(id, newsDto);
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

        // DELETE /<NewsController>/id
        /// <summary>
        /// Delete a News specified by id.
        /// </summary>
        /// <param name="id">A integer number.</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_newsService.EntityExists(id))
                return NotFound();

            await _newsService.DeleteNews(id);

            return Ok();
        }


    }
}
