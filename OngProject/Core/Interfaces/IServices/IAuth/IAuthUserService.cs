using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Entities.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices.IAuth
{
    public interface IAuthUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);


        Task<UserManagerResponse> Login(LoginUserModel model);
        Task<UserDto> MeAsync(ClaimsPrincipal user);
    }

    
}
