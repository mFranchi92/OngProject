using OngProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IRepositories
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization> GetById(int id);
        Task Insert(Organization entity);
        Task<bool> Update(Organization entity);
        Task<bool> Delete(int id);
    }
}
