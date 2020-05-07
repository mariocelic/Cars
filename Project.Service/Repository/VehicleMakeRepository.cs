using Project.Service.Data;
using Project.Service.Interfaces;


namespace Project.Service.Repository
{
    public class VehicleMakeRepository : AsyncRepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        private ApplicationDbContext _context;

        public VehicleMakeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
