using Project.Service.Data;
using Project.Service.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMake>
    {
        Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        
    }
}
