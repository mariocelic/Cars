using Project.Service.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Project.Service.Interfaces
{
    public interface IVehicleModelRepository : IAsyncRepositoryBase<VehicleModel>
    {
        IQueryable<VehicleModel> FindAllWithMake();
        Task<VehicleModel> FindByIdWithMake(int id);
    }
}
