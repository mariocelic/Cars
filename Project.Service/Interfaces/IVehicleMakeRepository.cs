using Project.Service.Data;
<<<<<<< HEAD
using System.Linq;
=======
using Project.Service.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeRepository : IAsyncRepositoryBase<VehicleMake>
    {
<<<<<<< HEAD
        IQueryable<VehicleMake> FindAllAsync();        

=======
        Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
        
>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0
    }
}
