using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices.IGetUri;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUriService _uriService;

        public TestimonialService(IUnitOfWork unitOfWork, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _uriService = uriService;
        }

        public async Task<ResponsePagination<GenericPagination<Testimonial>>> GetTestimonials(int page, int pageSize, string routeName)
        {
            var testimonials = await _unitOfWork.TestimonialRepository.GetAll();

            page = page == 0 ? 1 : page;
            pageSize = pageSize == 0 ? 10 : pageSize;

            var nextRoute = $"{routeName}?page={page + 1}&pageSize={pageSize}";
            var previosRoute = $"{routeName}?page={page - 1}&pageSize={pageSize}";

            var pageTestimonials = GenericPagination<Testimonial>.Create(testimonials, page, pageSize);

            var result = new ResponsePagination<GenericPagination<Testimonial>>(pageTestimonials)
            {
                TotalRecords = pageTestimonials.TotalRecords,
                PageSize = pageTestimonials.PageSize,
                CurrentPage = pageTestimonials.CurrentPage,
                TotalPages = pageTestimonials.TotalPages,
                HasNextPage = pageTestimonials.HasNextPage,
                HasPreviousPage = pageTestimonials.HasPreviousPage,
            };

            if (result.HasNextPage)
                result.NextPageUrl = _uriService.GetPaginationUri(page, nextRoute).ToString();
            if (result.HasPreviousPage)
                result.PreviousPageUrl = _uriService.GetPaginationUri(page, previosRoute).ToString();

            return result;
        }

        public async Task<Testimonial> GetById(int id)
        {
            return await _unitOfWork.TestimonialRepository.GetById(id);
        }

        public async Task Insert(TestimonialDto testimonialdto)
        {
            try
            {
                var map = new EntityMapper();
                var testimonial = map.FromTestimonialDtoToTestimonial(testimonialdto);
                if (testimonialdto.Image != null)
                {
                    if (ValidateFiles.ValidateImage(testimonialdto.Image))
                    { 
                        var s3helper = new S3AwsHelper();
                        string key = DateTime.Now.ToString();
                        key = key.Replace(":", "").Replace("/", "").Replace(" ", "");

                        var result = await s3helper.AwsUploadFile("testimonial_" + key, testimonialdto.Image);
                        if (result.Code == 200)
                        {
                            testimonial.Image = result.Url;
                            await _unitOfWork.TestimonialRepository.Insert(testimonial);
                            await _unitOfWork.SaveChangesAsync();
                        }
                        else
                            throw new Exception(result.Errors);
                    }
                    else
                        throw new Exception("File not valid");
                }
                else
                {
                    await _unitOfWork.TestimonialRepository.Insert(testimonial);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(int id, TestimonialEditDto testimonialDto)
        {
            try
            {
                if (_unitOfWork.TestimonialRepository.EntityExists(id))
                {
                    var testimonial = await _unitOfWork.TestimonialRepository.GetById(id);
                        testimonial.Name = testimonialDto.Name;
                        testimonial.Content = testimonialDto.Content;

                    if (testimonialDto.Image != null)
                    {
                        if (ValidateFiles.ValidateImage(testimonialDto.Image))
                        {
                            var s3helper = new S3AwsHelper();
                            var result = await s3helper.AwsUploadFile(testimonial.Image.Substring(testimonial.Image.IndexOf("testimonial_")), testimonialDto.Image);
                            if (result.Code == 200)
                            {
                                await _unitOfWork.TestimonialRepository.Update(testimonial);
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
                        await _unitOfWork.TestimonialRepository.Update(testimonial);
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

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.TestimonialRepository.Delete(id);
            return true;
        }

        
    }
}
