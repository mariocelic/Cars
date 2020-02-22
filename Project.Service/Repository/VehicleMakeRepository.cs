using Cars.Data;
using Project.Service.Data;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Service.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private ApplicationDbContext _context;
        public VehicleMakeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(VehicleMake entity)
        {
            _context.VehicleMakes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(VehicleMake entity)
        {
            _context.VehicleMakes.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<VehicleMake> GetAll()
        {
            var vehicleMakes = _context.VehicleMakes.ToList();
            return vehicleMakes;
            
        }

        public VehicleMake GetById(int id)
        {
            var vehicleMake = _context.VehicleMakes.Find(id);
            return vehicleMake;
        }

        public void Update(VehicleMake entity)
        {
            _context.VehicleMakes.Update(entity);
            _context.SaveChanges();        
        }
    }
}
