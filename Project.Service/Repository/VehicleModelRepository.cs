using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class VehicleModelRepository : AsyncRepositoryBase<VehicleModel>, IVehicleModelRepository
    {
        private ApplicationDbContext _context;

        public VehicleModelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleModel>> GetAllWithMake()
        {
            var models = await _context.Set<VehicleModel>()
               .Include(q => q.VehicleMake)               
               .ToListAsync(); ;
            return models;
        }

        public async Task<VehicleModel> GetByIdWithMake(int id)
        {
            var model = await _context.Set<VehicleModel>()
                .Include(q => q.VehicleMake)
                .FirstOrDefaultAsync(q => q.ModelId == id);
            return model;
        }
    }
}
