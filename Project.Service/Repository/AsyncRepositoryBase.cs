using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Helpers;
using Project.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class AsyncRepositoryBase<T> : IAsyncRepositoryBase<T> where T : class

    {
        private readonly ApplicationDbContext _context;


        public AsyncRepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<T>> FindAll()
        {
            return await _context.Set<T>().ToListAsync();     
        }

        

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }


        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);



        }
    }
}
