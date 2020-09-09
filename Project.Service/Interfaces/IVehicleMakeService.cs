using Project.Service.Data;
using Project.Service.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeService
    {
<<<<<<< HEAD
        Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
=======
        public Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams);
>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0
        Task<VehicleMake> FindVehicleMakeById(int id);          
        Task<VehicleMake> CreateAsync(VehicleMake vehicleMake);
        Task<VehicleMake> UpdateAsync(int id, VehicleMake vehicleMake);
        Task<VehicleMake> DeleteAsync(int id);       
        
    }
}
