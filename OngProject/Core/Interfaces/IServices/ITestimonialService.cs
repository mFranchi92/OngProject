using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITestimonialService
{
    Task<ResponsePagination<GenericPagination<Testimonial>>> GetTestimonials(int page, int pageSize, string routeName);
    Task<Testimonial> GetById(int id);
    Task Insert(TestimonialDto entity);
    Task<bool> Update(int id, TestimonialEditDto entity);
    Task<bool> Delete(int id);
}
