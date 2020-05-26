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
            VehicleMake = new VehicleMakeRepository(context);
            VehicleModel = new VehicleModelRepository(context);

        }

        public IVehicleMakeRepository VehicleMake { get; private set; }
        public IVehicleModelRepository VehicleModel { get; private set; }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.DisposeAsync();
        }

        
    }
}
