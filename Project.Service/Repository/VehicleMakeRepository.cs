using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Interfaces;
using System.Linq;

namespace Project.Service.Repository
{
    public class VehicleMakeRepository : AsyncRepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        private readonly ApplicationDbContext _context;


        public VehicleMakeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public IQueryable<VehicleMake> FindAllAsync()
        {
            return _context.VehicleMakes.AsNoTracking();
        }
    }    
}
