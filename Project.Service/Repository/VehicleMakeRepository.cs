using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private ApplicationDbContext _context;
        public VehicleMakeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(VehicleMake entity)
        {
            await _context.Set<VehicleMake>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<VehicleMake>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VehicleMake>> GetAll()
        {
            return await _context.Set<VehicleMake>().ToListAsync();
        }

        public async Task<VehicleMake> GetById(int id)
        {
           return await _context.Set<VehicleMake>().FindAsync(id);            
        }

        public async Task Update(VehicleMake entity)
        {
            _context.Set<VehicleMake>().Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
