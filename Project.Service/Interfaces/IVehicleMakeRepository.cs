using Project.Service.Data;
using System.Linq;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMake>
    {
        IQueryable<VehicleMake> FindAllAsync();        

    }
}
