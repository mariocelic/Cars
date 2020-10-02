using Project.Service.Data;
using Project.Service.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMake>
    {
        IQueryable<VehicleMake> FindAllAsync();

        Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);

    }
}
