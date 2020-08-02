using Project.Service.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> FindAllMakesPagedAsync();
        Task<VehicleMake> FindVehicleMakeById(int id);
        Task<VehicleMake> CreateAsync(VehicleMake vehicleMake);
        Task<VehicleMake> UpdateAsync(int id, VehicleMake vehicleMake);
        Task<VehicleMake> DeleteAsync(int id);
    }
}
