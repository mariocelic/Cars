using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class VehicleModelRepository : AsyncRepositoryBase<VehicleModel>, IVehicleModelRepository
    {
        private readonly ApplicationDbContext _context;        

        public VehicleModelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;           
        }

        
        public IQueryable<VehicleModel> FindAllWithMake()
        {
            return _context.Set<VehicleModel>()
               .AsNoTracking()
               .Include(q => q.VehicleMake);                           
        }

        public async Task<VehicleModel> FindByIdWithMake(int id)
        {
            return await _context.Set<VehicleModel>()
                .AsNoTracking()
                .Include(q => q.VehicleMake)
                .FirstOrDefaultAsync(q => q.ModelId == id);

        }
    }
}
