using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface ISlideService
    {
        Task<IEnumerable<SlideDto>> GetAllSlides();

        Task<Slide> GetSlideById(int id);

        Task InsertSlide(SlideCreateDto slide);

        Task<bool> UpdateSlide(int id, SlideCreateDto slide);

        Task<bool> DeleteSlide(int id);
        
        bool EntityExists(int id);
    }
}
