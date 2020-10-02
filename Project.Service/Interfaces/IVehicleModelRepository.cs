using Project.Service.Data;
using Project.Service.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project.Service.Interfaces
{
    public interface IVehicleModelRepository : IAsyncRepositoryBase<VehicleModel>
    {
        IQueryable<VehicleModel> FindAllWithMake();
        Task<VehicleModel> FindByIdWithMake(int id);
        Task<IList<VehicleModel>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
    }
}
