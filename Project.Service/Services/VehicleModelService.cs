using Project.Service.Data;
using Project.Service.Helpers;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        public Task<VehicleModel> CreateAsync(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleModel>> FindAllModelsPagedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> FindVehicleMakeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> UpdateAsync(int id, VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
