using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.IGetUri;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class NewsService : INewsService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUriService _uriService;

        public NewsService(IUnitOfWork unitOfWork, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _uriService = uriService;
        }

        public async Task<bool> DeleteNews(int id)
        {
            await _unitOfWork.NewsRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ResponsePagination<GenericPagination<News>>> GetAllNews(int page, int pageSize, string controller)
        {
            
            var news = await _unitOfWork.NewsRepository.GetAll();

            
            page = page == 0 ? 1 : page;
            pageSize = pageSize == 0 ? 10 : pageSize;

            
            var nextRoute = $"{controller}/?page={(page + 1)}";
            var previousRoute = $"{controller}/?page={(page - 1)}";


            //get a page(entity, NumberPage, PageSize)
            var newsPage = GenericPagination<News>.Create(news, page, pageSize);

            //response with necessary information 
            var result = new ResponsePagination<GenericPagination<News>>(newsPage)
            {
                TotalRecords = newsPage.TotalRecords,
                PageSize = newsPage.PageSize,
                CurrentPage = newsPage.CurrentPage,
                TotalPages = newsPage.TotalPages,
                HasNextPage = newsPage.HasNextPage,
                HasPreviousPage = newsPage.HasPreviousPage,
            };

            //setUrls
            if (result.HasNextPage)
                result.NextPageUrl = _uriService.GetPaginationUri(page, nextRoute).ToString();
            if (result.HasPreviousPage)
                result.PreviousPageUrl = _uriService.GetPaginationUri(page, previousRoute).ToString();

            return result;
        }

        public async Task<News> GetNewsById(int id)
        {
            return await _unitOfWork.NewsRepository.GetById(id);
        }

        public async Task InsertNews(NewsDto newsDto)
        {
            try
            {
                var map = new EntityMapper();
                var news = map.FromNewsDtoToNews(newsDto);
                if (newsDto.Image != null)
                {
                    if (ValidateFiles.ValidateImage(newsDto.Image))
                    {
                        var s3helper = new S3AwsHelper();
                        string key = DateTime.Now.ToString();
                        key = key.Replace(":", "");
                        key = key.Replace("/", "");
                        key = key.Replace(" ", "");
                        var result = await s3helper.AwsUploadFile("news_" + key, newsDto.Image);

                        if (result.Code == 200)
                        {
                            news.Image = result.Url;
                            await _unitOfWork.NewsRepository.Insert(news);
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
                    await _unitOfWork.NewsRepository.Insert(news);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateNews(int id, NewsUpdateDto newsDto)
        {
            try
            {
                if (_unitOfWork.NewsRepository.EntityExists(id))
                {
                    var news = await _unitOfWork.NewsRepository.GetById(id);
                    if (newsDto.Name != null)
                        news.Name = newsDto.Name;
                        news.Content = newsDto.Content;
                    if (newsDto.Image != null)
                    {
                        if (ValidateFiles.ValidateImage(newsDto.Image))
                        {
                            var s3helper = new S3AwsHelper();
                            var result = await s3helper.AwsUploadFile(news.Image.Substring(news.Image.IndexOf("news_")), newsDto.Image);
                            if (result.Code == 200)
                            {
                                await _unitOfWork.NewsRepository.Update(news);
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
                        await _unitOfWork.NewsRepository.Update(news);
                        await _unitOfWork.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EntityExists(int id)
        {
            return _unitOfWork.NewsRepository.EntityExists(id);
        }
    }

}