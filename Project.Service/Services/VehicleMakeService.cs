using AutoMapper;
using Project.Service.Data;
using Project.Service.Helpers;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace Project.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }


        public async Task<VehicleMake> CreateAsync(VehicleMake vehicleMake)
        {
            await _unitOfWork.VehicleMake.Create(vehicleMake);
            await _unitOfWork.CommitAsync();

            return vehicleMake;

        }

        public async Task<VehicleMake> DeleteAsync(int id)
        {
            var make = await _unitOfWork.VehicleMake.FindById(id);

            await _unitOfWork.VehicleMake.Delete(id);
            await _unitOfWork.CommitAsync();
            return make;
        }

        public async Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {
            
            IQueryable<VehicleMake> vehicleMakes;

            // Filtering
            using (_context)
            {
                try
                {

                    if (filteringParams.FilterString != null)
                    {
                        pagingParams.PageNumber = 1;
                    }
                    else
                    {
                        filteringParams.FilterString = filteringParams.CurrentFilter;
                    }


                    if (!string.IsNullOrEmpty(filteringParams.FilterString))
                    {
                        vehicleMakes = _unitOfWork.VehicleMake.FindAllAsync().Where(q => q.Name.Contains(filteringParams.FilterString)).AsQueryable();
                    }
                    else vehicleMakes = null;

                    //sorting
                    switch (sortingParams.SortOrder)
                    {
                        case "name_desc":
                            vehicleMakes = vehicleMakes != null ? vehicleMakes.OrderByDescending(q => q.Name).AsQueryable() : _unitOfWork.VehicleMake.FindAllAsync().OrderByDescending(q => q.Name).AsQueryable();
                            break;

                        default:
                            vehicleMakes = vehicleMakes != null ? vehicleMakes.OrderBy(q => q.Name).AsQueryable() : _unitOfWork.VehicleMake.FindAllAsync().OrderBy(q => q.Name).AsQueryable();
                            break;
                    }

                    return _mapper.Map<IList<VehicleMake>>(await PaginationList<VehicleMake>.CreateAsync(vehicleMakes, pagingParams.PageNumber ?? 1, pagingParams.PageSize ?? 5)).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<VehicleMake> FindVehicleMakeById(int id)
        {
            return await _unitOfWork.VehicleMake.FindById(id);
        }

        public async Task<VehicleMake> UpdateAsync(int id, VehicleMake vehicleMake)
        {
            var vehicleMakeToUpdate = await _unitOfWork.VehicleMake.FindById(id);

            if (string.IsNullOrEmpty(vehicleMake.Name))
            {
                vehicleMakeToUpdate.Name = vehicleMakeToUpdate.Name;
            }
            else
            {
                vehicleMakeToUpdate.Name = vehicleMake.Name;
            }


            if (string.IsNullOrEmpty(vehicleMake.Abrv))
            {
                vehicleMakeToUpdate.Abrv = vehicleMakeToUpdate.Abrv;
            }
            else
            {
                vehicleMakeToUpdate.Abrv = vehicleMake.Abrv;
            }

            _unitOfWork.VehicleMake.Update(vehicleMakeToUpdate);
            await _unitOfWork.CommitAsync();


            return vehicleMakeToUpdate;

        }
    }
}
