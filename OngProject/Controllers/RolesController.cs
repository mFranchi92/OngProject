using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService rolesService;

        public RolesController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<Rol>> Get()
        //{
        //    return await rolesService.GetAll();
        //}

        //[HttpGet("{id}")]
        //public async Task<Rol> Get(int id)
        //{
        //    return await rolesService.GetById(id);
        //}

        //[HttpPost]
        //public async Task Post([FromBody] Rol rol)
        //{
        //    await rolesService.Insert(rol);
        //}

        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody] Rol rol)
        //{
        //    await rolesService.Update(rol);
        //}

        //[HttpDelete("{id}")]
        //public async Task Delete(int id)
        //{
        //    await rolesService.Delete(id);
        //}
    }
}
