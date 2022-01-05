using OngProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IRepositories
{
    public interface ITestimonialRepository
    {
        Task<IEnumerable<Testimonial>> GetAll();
        Task<Testimonial> GetById(int id);
        Task Insert(Testimonial entity);
        Task<bool> Update(Testimonial entity);
        Task<bool> Delete(int id);
    }
}
