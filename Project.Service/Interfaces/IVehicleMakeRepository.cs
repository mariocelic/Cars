using Project.Service.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMake>
    {
        Task<IEnumerable<VehicleMake>> FindAllMakes();       

    }
}
