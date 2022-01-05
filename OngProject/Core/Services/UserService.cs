using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Entities.AuthModel;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
       
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IdentityResult> Insert(User entity)
        {
            var result = await _userManager.CreateAsync(entity);
            return result;
        }

        public async Task<UserManagerResponse> Update(UserUpdateDto entity, ClaimsPrincipal user)
        {
            try
            {
                AwsManagerResponse imageResult = new AwsManagerResponse(); ;
                var s3helper = new S3AwsHelper();
                var _userId = user.Claims.Where(x => x.Type == "UserId").FirstOrDefault()?.Value;
                User _user = await _userManager.FindByIdAsync(_userId);
                _user.FirstName = entity.FirstName;
                _user.LastName = entity.LastName;
                if (entity.Photo != null && ValidateFiles.ValidateImage(entity.Photo))
                {
                    var id = Guid.NewGuid().ToString();
                    imageResult = await s3helper.AwsUploadFile(id, entity.Photo);
                    _user.Photo = imageResult.Url;
                }
                var response = await _userManager.UpdateAsync(_user);
                var _UMresponse = new UserManagerResponse();
                if (response.Succeeded)
                {
                    _UMresponse.IsSuccess = true;
                    _UMresponse.Message = "User Updated!";
                    if (imageResult.Errors != null)
                    {
                        _UMresponse.Errors.Prepend(imageResult.Errors);
                    }
                }
                else
                {
                    _UMresponse.IsSuccess = false;
                    _UMresponse.Message = "Cant Update User";
                    _UMresponse.Errors = (IEnumerable<string>)response.Errors;
                }
                return _UMresponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IdentityResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsDeleted = true;
            var result =  await _userManager.UpdateAsync(user);
            return result;
        }
    }
}
