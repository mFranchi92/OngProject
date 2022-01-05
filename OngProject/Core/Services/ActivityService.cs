using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteActivity(int id)
        {
            await _unitOfWork.ActivityRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Activity> GetActivityById(int id)
        {
            return await _unitOfWork.ActivityRepository.GetById(id);
        }

        public async Task<IEnumerable<Activity>> GetAllActivities()
        {
            return await _unitOfWork.ActivityRepository.GetAll();
        }

        public async Task<GenericResult> InsertActivity(ActivityInsertDto entity)
        {
            Activity activity = new Activity();
            AwsManagerResponse imageResult = new AwsManagerResponse(); ;
            var s3helper = new S3AwsHelper();
            if (entity.Image != null && ValidateFiles.ValidateImage(entity.Image))
            {
                var id = Guid.NewGuid().ToString();
                imageResult = await s3helper.AwsUploadFile(id, entity.Image);
                if (imageResult.Code == 200)
                {
                    activity.Image = imageResult.Url;
                    activity.Content = entity.Content;
                    activity.Name = entity.Name;
                    await _unitOfWork.ActivityRepository.Insert(activity);
                    await _unitOfWork.SaveChangesAsync();
                    return new GenericResult
                    {
                        IsSuccess = true,
                        Message = "Activity created succesfully"
                    };
                }
                else
                {
                    return new GenericResult
                    {
                        IsSuccess = false,
                        Message = "Activity creation error. Image not created, try again"
                    };
                }
            }
            return new GenericResult
            {
                IsSuccess = false,
                Message = "Image extension not valid"
            };
        }

        public async Task<bool> UpdateActivity(int id, ActivityUpdateDto activityUpdateDto)
        {
            try
            {
                if (_unitOfWork.ActivityRepository.EntityExists(id))
                {
                    var activity = await _unitOfWork.ActivityRepository.GetById(id);
                    activity.Name = activityUpdateDto.Name;
                    activity.Content = activityUpdateDto.Content;

                    if (activityUpdateDto.Image != null)
                    {
                        if (ValidateFiles.ValidateImage(activityUpdateDto.Image))
                        {
                            var s3helper = new S3AwsHelper();
                            var result = await s3helper.AwsUploadFile(Guid.NewGuid().ToString(), activityUpdateDto.Image);
                            if (result.Code == 200)
                            {
                                activity.Image = result.Url;
                                await _unitOfWork.ActivityRepository.Update(activity);
                                await _unitOfWork.SaveChangesAsync();
                                return true;
                            }
                            else
                                throw new Exception(result.Errors);
                        }
                        else
                            throw new Exception("Image not valid");
                    }
                    else
                    {
                        await _unitOfWork.ActivityRepository.Update(activity);
                        await _unitOfWork.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Activity entity)
        {

            await _unitOfWork.ActivityRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}


