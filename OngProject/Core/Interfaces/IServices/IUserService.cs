using Microsoft.AspNetCore.Identity;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Entities.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task<IdentityResult> Insert(User entity);
        Task<UserManagerResponse> Update(UserUpdateDto entity, ClaimsPrincipal user);
        Task<IdentityResult> Delete(string id);
    }
}
