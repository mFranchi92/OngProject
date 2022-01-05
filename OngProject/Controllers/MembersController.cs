using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.IGetUri;
using OngProject.Core.Services.GetUri;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
           _memberService = memberService;
        }
        // GET: api/<MembersController>
        /// <summary>
        /// Get all members of the selected page.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet(Name = nameof(GetPage))]
        public async Task<IActionResult> GetPage(int page, int pageSize)
        {
            var members = await _memberService.GetMembers(page, pageSize, Url.RouteUrl(nameof(GetPage)));
            return Ok(members);
        }
        /// <summary>
        /// Create Member
        /// </summary>
        /// <param name="memberDto"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] MemberDto memberDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _memberService.InsertMember(memberDto);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// Update a specific Member
        /// </summary>
        /// <param name="id"></param>
        /// <param name="memberDto"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] MemberEditDto memberDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _memberService.UpdateMember(id, memberDto);
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
        /// <summary>
        /// Delete a specific Member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!_memberService.EntityExists(id))
            {
                return NotFound();
            }

            await _memberService.DeleteMember(id);

            return Ok();

        }

    }
}
