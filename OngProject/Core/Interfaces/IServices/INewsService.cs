using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface INewsService
    {
        Task<ResponsePagination<GenericPagination<News>>> GetAllNews(int page, int pageSize, string controller);

        Task<News> GetNewsById(int id);

        Task InsertNews(NewsDto newsDto);

        Task<bool> UpdateNews(int id, NewsUpdateDto newsDto);

        Task<bool> DeleteNews(int id);
        
        bool EntityExists(int id);
    }
}
