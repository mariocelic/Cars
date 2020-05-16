using Project.Service.Data;
using Project.Service.Interfaces;
using Project.Service.Repository;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork (ApplicationDbContext context)
        {
            _context = context;
            VehicleMake = new VehicleMakeRepository(_context);
            VehicleModel = new VehicleModelRepository(_context);

        }

        public IVehicleMakeRepository VehicleMake { get; private set; }
        public IVehicleModelRepository VehicleModel { get; private set; }

        
        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public async Task Commit()
        {
             await _context.SaveChangesAsync();
        }
    }
}
