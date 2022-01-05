using OngProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;

namespace OngProject.Core.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoryAll();

        Task<Category> GetCategoryById(int id);

        Task<ResponsePagination<GenericPagination<Category>>> GetCategories(int page, string controller);

        Task InsertCategory(Category category);
        Task InsertCategory(CategoryCreateDto categoryCreateDto);

        Task<bool> UpdateCategory(Category category);
        Task<bool> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);

        Task<bool> DeleteCategory(int id);
        
        bool EntityExists(int id);
    }
}
