using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationDto>> GetAll();
        Task<OrganizationDto> GetById(int id);
        Task Insert(Organization entity);
        Task<bool> Update(Organization entity);
        Task<bool> Delete(int id);
        Task<bool> UpdatePublicProperties(int id, OrganizationDto organizationDto);
        GenericResult GetOrganizationWithSlides();
    }
}