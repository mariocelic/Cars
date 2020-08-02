using AutoMapper;
using Project.Service.Data;
using Project.Service.Helpers;
using Project.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace Project.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<VehicleMake> CreateAsync(VehicleMake vehicleMake)
        {
            await _unitOfWork.VehicleMake.Create(vehicleMake);
            await _unitOfWork.CommitAsync();

            return vehicleMake;
        }

        public async Task<VehicleMake> DeleteAsync(int id)
        {
            var make = await _unitOfWork.VehicleMake.GetById(id);
           
            await _unitOfWork.VehicleMake.Delete(id);
            await _unitOfWork.CommitAsync();
            return make;
        }

        public async Task<IEnumerable<VehicleMake>> FindAllMakesPagedAsync()
        {
            return await _unitOfWork.VehicleMake.FindAllMakes();
        }


        public Task<VehicleMake> FindVehicleMakeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<VehicleMake> UpdateAsync(int id, VehicleMake vehicleMake)
        {
            throw new System.NotImplementedException();
        }
    }
}

