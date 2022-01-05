using Microsoft.AspNetCore.Http;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class SlideService : ISlideService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SlideService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteSlide(int id)
        {
            await _unitOfWork.SlideRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SlideDto>> GetAllSlides()
        {
            var slides = await _unitOfWork.SlideRepository.GetAll();

            EntityMapper mapper = new();

            var slidesDtoList = slides.Select(x => mapper.FromSlideToSlideDto(x)).ToList();

            return slidesDtoList;
        }

        public async Task<Slide> GetSlideById(int id)
        {
            return await _unitOfWork.SlideRepository.GetById(id);
        }

        public async Task InsertSlide(SlideCreateDto slideCreateDto)
        {
            
            if (slideCreateDto.Order == null)
            {
                int valueMax = (int)(_unitOfWork.SlideRepository.ColumnMax(x => (int?)x.Order) ?? 0);
                slideCreateDto.Order = valueMax + 1;
            }
                
            byte[] bytesFile = Convert.FromBase64String(slideCreateDto.ImageBase64);
            string fileExtension = ValidateFiles.GetImageExtensionFromFile(bytesFile);
            
            string uniqueName = "slide_" + DateTime.Now.ToString().Replace(",", "").Replace("/", "").Replace(" ", "");

            FormFileData formFileData = new()
            {
                FileName = uniqueName + fileExtension,
                ContentType = "Image/" + fileExtension.Replace(".",""),
                Name = null
            };

            IFormFile ImageFormFile = ConvertFiles.BinaryToFormFile(bytesFile, formFileData);

            S3AwsHelper s3Helper = new();
            var result = await s3Helper.AwsUploadFile(uniqueName, ImageFormFile);
            
            if(result.Code == 200)
            {
                slideCreateDto.ImageBase64 = result.Url;

                EntityMapper mapper = new();
                Slide slide = mapper.FromSlideCreateDtoToSlide(slideCreateDto);

                await _unitOfWork.SlideRepository.Insert(slide);
                await _unitOfWork.SaveChangesAsync();
            }
            else
                throw new Exception(result.Errors);
        }

        public async Task<bool> UpdateSlide(int id, SlideCreateDto slideCreateDto)
        {
            if (!(_unitOfWork.OrganizationRepository.EntityExists(slideCreateDto.OrganizationId)))
                return false;
            
            var existingSlide = await _unitOfWork.SlideRepository.GetById(id);
            if (existingSlide == null)
                return false;

            if (slideCreateDto.Order == null)
            {
                int valueMax = (int)(_unitOfWork.SlideRepository.ColumnMax(x => (int?)x.Order) ?? 0);
                slideCreateDto.Order = valueMax + 1;
            }

            if(slideCreateDto.ImageBase64 != null)
            {
                byte[] bytesFile = Convert.FromBase64String(slideCreateDto.ImageBase64);
                string fileExtension = ValidateFiles.GetImageExtensionFromFile(bytesFile);

                string uniqueName = "slide_" + DateTime.Now.ToString().Replace(",", "").Replace("/", "").Replace(" ", "");

                FormFileData formFileData = new()
                {
                    FileName = uniqueName + fileExtension,
                    ContentType = "Image/" + fileExtension.Replace(".", ""),
                    Name = null
                };

                IFormFile ImageFormFile = ConvertFiles.BinaryToFormFile(bytesFile, formFileData);

                S3AwsHelper s3Helper = new();
                var result = await s3Helper.AwsUploadFile(uniqueName, ImageFormFile);

                if (result.Code == 200)
                {
                    existingSlide.ImageUrl = result.Url;
                }
                else
                    throw new Exception(result.Errors);
            }

            existingSlide.Order = (int)slideCreateDto.Order;
            existingSlide.Text = slideCreateDto.Text;
            existingSlide.OrganizationId = slideCreateDto.OrganizationId;

            await _unitOfWork.SlideRepository.Update(existingSlide);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public bool EntityExists(int id)
        {
           return _unitOfWork.SlideRepository.EntityExists(id);
        }
}
}
