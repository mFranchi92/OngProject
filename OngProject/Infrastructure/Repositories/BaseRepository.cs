using Microsoft.EntityFrameworkCore;
using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IRepositories;
using OngProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace OngProject.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await _entities.Where(x => x.IsDeleted == false).ToListAsync();
            return list;
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.IsDeleted = false;
            await _entities.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
           _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            entity.IsDeleted = true;
            _entities.Update(entity);
        
        }

        public bool EntityExists(int id)
        {
            return _entities.Any(x => x.Id == id);
        }

        public object ColumnMax(Func<T, object> function)
        {
            var max = _entities.Select(function).Max();
            return max;
        }
    }
}
