using AutoMapper;
using Cars.ViewModels;
using Project.Service.Data;

namespace Cars.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<VehicleMake, VehicleMakeVM>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelVM>().ReverseMap();
        }

    }
}
