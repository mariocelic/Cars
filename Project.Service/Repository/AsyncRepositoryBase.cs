using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class AsyncRepositoryBase<T> : IAsyncRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public AsyncRepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IList<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        
        public async Task Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
        }

        public async Task Update(T entity)
        {
            dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
              
    }
}
