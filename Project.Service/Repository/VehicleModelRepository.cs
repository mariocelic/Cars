using Cars.Data;
using Project.Service.Data;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Service.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private ApplicationDbContext _context;
        public VehicleModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(VehicleModel entity)
        {
            _context.VehicleModels.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(VehicleModel entity)
        {
            _context.VehicleModels.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<VehicleModel> GetAll()
        {
            var vehicleModels = _context.VehicleModels.ToList();
            return vehicleModels;
        }

        public VehicleModel GetById(int id)
        {
            var vehicleModel = _context.VehicleModels.Find(id);
            return vehicleModel;
        }
        
        public void Update(VehicleModel entity)
        {
            _context.VehicleModels.Update(entity);
            _context.SaveChanges();
        }
    }
}
