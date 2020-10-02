using AutoMapper;
using Project.Service.Data;
using Project.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {

            CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();

            CreateMap<VehicleMakeDTO, IVehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModelDTO, IVehicleModelDTO>().ReverseMap();

        }

    }
}
