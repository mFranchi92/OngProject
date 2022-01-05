using OngProject.Core.Entities;
using OngProject.Core.Interfaces;
using OngProject.Core.Interfaces.IRepositories;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Mapper;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces.IServices.IGetUri;
using OngProject.Core.Helper.Pagination;

namespace OngProject.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUriService _uriService;

        public CategoryService(IUnitOfWork unitOfWork, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _uriService = uriService;
        }
        public async Task<ResponsePagination<GenericPagination<Category>>> GetCategories(int page, string controller)
        {
            int pageSize = 10;
            var category = await _unitOfWork.CategoryRepository.GetAll();

            page = page == 0 ? 1 : page;
            var rutaSiguiente = $"{controller}/?page={(page + 1)}";
            var rutaAnterior = $"{controller}/?page={(page - 1)}";


            //get a page(entity, NumberPage, PageSize)
            var pageCategories = GenericPagination<Category>.Create(category, page, pageSize);

            //response with necessary information 
            var result = new ResponsePagination<GenericPagination<Category>>(pageCategories)
            {
                TotalRecords = pageCategories.TotalRecords,
                PageSize = pageCategories.PageSize,
                CurrentPage = pageCategories.CurrentPage,
                TotalPages = pageCategories.TotalPages,
                HasNextPage = pageCategories.HasNextPage,
                HasPreviousPage = pageCategories.HasPreviousPage,
            };

            //setUrls
            if (result.HasNextPage)
                result.NextPageUrl = _uriService.GetPaginationUri(page, rutaSiguiente).ToString();
            if (result.HasPreviousPage)
                result.PreviousPageUrl = _uriService.GetPaginationUri(page, rutaAnterior).ToString();

            return result;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryAll()
        {
            var mapper = new EntityMapper();
            var categoryList = await _unitOfWork.CategoryRepository.GetAll();

            return mapper.FromCategoryListCategoryDtoList(categoryList);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.CategoryRepository.GetById(id);
        }

        public async Task InsertCategory(Category category)
        {
            await _unitOfWork.CategoryRepository.Insert(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            await _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                if (_unitOfWork.CategoryRepository.EntityExists(id))
                {
                    var category = await GetCategoryById(id);
                    category.Description = categoryUpdateDto.Description;
                    category.Name = categoryUpdateDto.Name;

                    if (categoryUpdateDto.Name != null)
                        category.Name = categoryUpdateDto.Name;
                    if (categoryUpdateDto.Description != null)
                        category.Description = categoryUpdateDto.Description;
                    if (categoryUpdateDto.Image != null)
                    {
                        if (ValidateFiles.ValidateImage(categoryUpdateDto.Image))
                        {
                            var s3helper = new S3AwsHelper();
                            var result = await s3helper.AwsUploadFile(category.Image.Substring(category.Image.IndexOf("category_")), categoryUpdateDto.Image);
                            if (result.Code == 200)
                            {
                                await _unitOfWork.CategoryRepository.Update(category);
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
                        await _unitOfWork.CategoryRepository.Update(category);
                        await _unitOfWork.SaveChangesAsync();
                        return true;
                    }
                }
                throw new Exception("Category not found.");
            }
            catch (Exception)
            {
                return false;
            }

        }


        public async Task<bool> DeleteCategory(int id)
        {
            await _unitOfWork.CategoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public bool EntityExists(int id)
        {
            return _unitOfWork.CategoryRepository.EntityExists(id);
        }
        public async Task InsertCategory(CategoryCreateDto categoryCreateDto)
        {

            if (categoryCreateDto.Image is null)
                throw new ArgumentNullException("Image");

            try
            {
                var map = new EntityMapper();
                var category = map.FromCategoryCreateDtoToCategory(categoryCreateDto);
                var s3helper = new S3AwsHelper();
                string key = DateTime.Now.ToString();
                key = key.Replace(":", "");
                key = key.Replace("/", "");
                key = key.Replace(" ", "");
                var result = await s3helper.AwsUploadFile("category_" + key, categoryCreateDto.Image);

                if (result.Code == 200)
                {
                    category.Image = result.Url;
                }
                else
                    throw new Exception(result.Errors);

                await _unitOfWork.CategoryRepository.Insert(category);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}






