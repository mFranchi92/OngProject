using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPage(int page)
        {
            var categories = await _categoryService.GetCategories(page, Url.RouteUrl(nameof(GetPage)));
            return Ok(categories);
        }


        // GET /<CategoriesController>/5
        /// <summary>
        /// Get a specific Categorie.
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize(Roles = ("Admin"))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // DELETE /<CategoriesController>/id
        /// <summary>
        /// Deletes a specific Categorie.
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize(Roles = ("Admin"))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_categoryService.EntityExists(id))
                return NotFound();

            await _categoryService.DeleteCategory(id);

            return Ok();
        }

        /// <summary>
        /// Create a Categorie.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoryCreateDto categoryCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            try
            {
                await _categoryService.InsertCategory(categoryCreateDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Update a specific Categorie.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize(Roles = ("Admin"))]
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCategory(int id, [FromForm] CategoryUpdateDto category)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _categoryService.UpdateCategory(id, category);
                    if (result)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
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
