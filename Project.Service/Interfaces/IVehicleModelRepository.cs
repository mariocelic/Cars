using Project.Service.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleModelRepository : IAsyncRepositoryBase<VehicleModel>
    {
        Task<IEnumerable<VehicleModel>> GetAllWithMake();
        Task<VehicleModel> GetByIdWithMake(int id);
    }
}
