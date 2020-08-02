using Project.Service.Data;
using Project.Service.Interfaces;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public IVehicleMakeRepository VehicleMake { get; set; }
        public IVehicleModelRepository VehicleModel { get; set; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(IVehicleMakeRepository vehicleMake, IVehicleModelRepository vehicleModel, ApplicationDbContext context)
        {
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;
            _context = context;
        }



        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.DisposeAsync();
        }


    }
}
