using AutoMapper;
using Cars.ViewModels;
using Project.Service.Data;
using Project.Service.DTO;
using Project.Service.Helpers;

namespace Cars.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<VehicleMake, VehicleMakeVM>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelVM>().ReverseMap();

            CreateMap<VehicleMake, VehicleMakeDto>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDto>().ReverseMap();          


        }

    }
}
