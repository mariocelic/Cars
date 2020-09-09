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
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        

        public VehicleModelService(IUnitOfWork unitOfWork,IMapper mapper, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<VehicleModel> CreateAsync(VehicleModel vehicleModel)
        {
            await _unitOfWork.VehicleModel.Create(vehicleModel);
            await _unitOfWork.CommitAsync();

            return vehicleModel;

        }

        public async Task<VehicleModel> DeleteAsync(int id)
        {
            var model = await _unitOfWork.VehicleModel.FindById(id);

            await _unitOfWork.VehicleModel.Delete(id);
            await _unitOfWork.CommitAsync();
            return model;
        }

        public async Task<IList<VehicleModel>> FindAllModelsPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {

            IQueryable<VehicleModel> vehicleModels;

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
                        vehicleModels = _unitOfWork.VehicleModel.FindAllWithMake().Where(q => q.VehicleMake.Name.Contains(filteringParams.FilterString)).AsQueryable();
                    }
                    else vehicleModels = null;

                    //sorting
                    switch (sortingParams.SortOrder)
                    {
                        case "name_desc":
                            vehicleModels = vehicleModels != null ? vehicleModels.OrderByDescending(q => q.VehicleMake.Name).AsQueryable() : _unitOfWork.VehicleModel.FindAllWithMake().OrderByDescending(q => q.VehicleMake.Name).AsQueryable();
                            break;

                        default:
                            vehicleModels = vehicleModels != null ? vehicleModels.OrderBy(q => q.VehicleMake.Name).AsQueryable() : _unitOfWork.VehicleModel.FindAllWithMake().OrderBy(q => q.VehicleMake.Name).AsQueryable();
                            break;
                    }

                    return _mapper.Map<IList<VehicleModel>>(await PaginationList<VehicleModel>.CreateAsync(vehicleModels, pagingParams.PageNumber ?? 1, pagingParams.PageSize ?? 5)).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }

    

        public async Task<VehicleModel> FindVehicleModelById(int id)
        {
            return await _unitOfWork.VehicleModel.FindByIdWithMake(id);
        }

        public async Task<VehicleModel> UpdateAsync(int id, VehicleModel vehicleModel)
        {
            var vehicleModelToUpdate = await _unitOfWork.VehicleModel.FindById(id);

            if (string.IsNullOrEmpty(vehicleModel.Name))
            {
                vehicleModelToUpdate.Name = vehicleModelToUpdate.Name;
            }
            else
            {
                vehicleModelToUpdate.Name = vehicleModel.Name;
            }


            if (string.IsNullOrEmpty(vehicleModel.Abrv))
            {
                vehicleModelToUpdate.Abrv = vehicleModelToUpdate.Abrv;
            }
            else
            {
                vehicleModelToUpdate.Abrv = vehicleModel.Abrv;
            }

            _unitOfWork.VehicleModel.Update(vehicleModelToUpdate);
            await _unitOfWork.CommitAsync();


            return vehicleModelToUpdate;

        }
    }
}
