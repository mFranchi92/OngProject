using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Entities.AuthModel;
using OngProject.Core.Interfaces.IServices.IAuth;
using OngProject.Core.Mapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Services.Auth
{
    public class AuthUserService : IAuthUserService
    {
        private UserManager<User> _userManager;
        private RoleManager<Rol> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthUserService(UserManager<User> userManager, IConfiguration configuration, RoleManager<Rol> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }



        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
                throw new NullReferenceException("Register Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var identityuser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,

            };

            var result = await _userManager.CreateAsync(identityuser, model.Password);

            if (result.Succeeded)
            {


                var user = _userManager.FindByEmailAsync(model.Email);
                await _userManager.AddToRoleAsync(await user, "Common");


                var token = GetToken(model.Email);
                return new UserManagerResponse
                {
                    IsSuccess = true,
                    Message = await token

                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }


        public async Task<string> GetToken(string mail)
        {
            var user = _userManager.FindByEmailAsync(mail);
            var userId = await _userManager.GetUserIdAsync(await user);



            //TODO: check required claims Role????
            var claimsArray = new List<Claim>
            {
                new Claim(ClaimTypes.Email, mail),
                new Claim("UserId", userId),


            };

            var userClaims = await _userManager.GetClaimsAsync(await user);
            var userRoles = await _userManager.GetRolesAsync(await user);
            claimsArray.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                claimsArray.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claimsArray.Add(roleClaim);
                    }
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenAuthentication:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["TokenAuthentication:Issuer"],
                audience: _configuration["TokenAuthentication:Audience"],
                claims: claimsArray,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;


        }

        public async Task<UserManagerResponse> Login(LoginUserModel model)
        {
            var user = _userManager.FindByEmailAsync(model.Email);

            var password = await _userManager.CheckPasswordAsync(await user, model.Password);


            if (user.Result == null || !password)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Wrong user or password"

                };
            }


            var token = GetToken(model.Email);
            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = await token

            };
        }

        public async Task<UserDto> MeAsync(ClaimsPrincipal user)
        {
            var _userId = user.Claims.Where(x => x.Type == "UserId").FirstOrDefault()?.Value;
            User _user = await _userManager.FindByIdAsync(_userId);
            EntityMapper mapper = new();
            var result = mapper.FromUserToUserDto(_user);
            return result;
        }
    }
}
