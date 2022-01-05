using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Interfaces;
using OngProject.Core.Interfaces.IRepositories;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {

        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

       /* [HttpGet]
        [Route("public/{id}")]
        public async Task<ActionResult> Public(int id)
        {
            var organization = await _organizationService.GetById(id);
            
            
            return Ok(organization);
        }*/
        [HttpGet]
        [Route("public")]
        public async Task<ActionResult> Public()
        {
            var orgDto =  _organizationService.GetOrganizationWithSlides();
            return Ok(orgDto);
        }

        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        [Route("public/{id}")]
        public async Task <ActionResult> Public(int id, [FromForm] OrganizationDto organizationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var organizations = await _organizationService.UpdatePublicProperties(id, organizationDto);
                return Ok(organizations);

            }
            catch (KeyNotFoundException nf)
            {

                return NotFound(nf.Message);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



       }
}
