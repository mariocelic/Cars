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
<<<<<<< HEAD
=======
            CreateMap<VehicleModel, VehicleModelVM>().ReverseMap();

            CreateMap<VehicleMake, VehicleMakeDto>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDto>().ReverseMap();          

>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0

            CreateMap<VehicleModel, VehicleModelVM>()
                .ForMember(dest => dest.VehicleMake, opts => opts.MapFrom(src => src.VehicleMake))
                .ReverseMap();
        }

    }
}
