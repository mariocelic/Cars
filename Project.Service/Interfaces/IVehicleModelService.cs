using Project.Service.Data;
using Project.Service.DTO;
using Project.Service.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> FindAllModelsPagedAsync();
        Task<VehicleModel> FindVehicleMakeById(int id);
        Task<VehicleModel> CreateAsync(VehicleModel vehicleModel);
        Task<VehicleModel> UpdateAsync(int id, VehicleModel vehicleModel);
        Task<VehicleModel> DeleteAsync(int id);
    }
}
