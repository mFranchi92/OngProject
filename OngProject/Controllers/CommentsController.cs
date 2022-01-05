using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OngProject.Core.DTOs;
using OngProject.Core.Mapper;
using System;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("/posts/{id}/[controller]")]
        [HttpGet]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentService.GetComment(id);
            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        [Authorize(Roles = ("Admin"))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return  Ok(await _commentService.GetComments());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (!await _commentService.ValidateCreatorOrAdminAsync(User, id))
            {
                return Forbid();
            }

            if (!_commentService.EntityExists(id))
            {
                return NotFound();
            }
            await _commentService.DeleteComment(id);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Insert(CommentInsertDto comment)
        {
            if (!User.Claims.Any())
            {
                return BadRequest("You must be logged to comment");
            }
            if (ModelState.IsValid)
            {
                var result = _commentService.InsertComment(comment, User);

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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentsAsync(int id, CommentUpdateDto comment)
        {
            try
            {
                if (!await _commentService.ValidateCreatorOrAdminAsync(User, comment.Id))
                {
                    return Forbid();
                }
                if (!_commentService.EntityExists(id))
                {
                    return NotFound("Comment doesn't exists");
                }
                if (ModelState.IsValid)
                {
                    var result = _commentService.UpdateComment(id, comment).Result;
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