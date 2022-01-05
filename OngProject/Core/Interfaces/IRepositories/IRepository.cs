using OngProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IRepositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        bool EntityExists(int id);
        Object ColumnMax(Func<T, Object> function);
    }
}
