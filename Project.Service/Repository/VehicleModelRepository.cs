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
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private ApplicationDbContext _context;
        public VehicleModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(VehicleModel entity)
        {
            await _context.Set<VehicleModel>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<VehicleModel>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<VehicleModel>> GetAll()
        {
            var models = await _context.Set<VehicleModel>()
               .Include(q => q.VehicleMake)
               .ToListAsync();               ;
            return models;
        }

        public async Task<VehicleModel> GetById(int id)
        {
            var model = await _context.Set<VehicleModel>()
                .Include(q => q.VehicleMake)
                .FirstOrDefaultAsync(q => q.ModelId == id);
            return model;
        }

        public async Task Update(VehicleModel entity)
        {
            _context.Set<VehicleModel>().Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
