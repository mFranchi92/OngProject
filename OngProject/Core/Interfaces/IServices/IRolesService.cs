using OngProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IRolesService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Rol>> GetAll();
        Task<Rol> GetById(int id);
        Task Insert(Rol entity);
        Task<bool> Update(Rol entity);
    }
}