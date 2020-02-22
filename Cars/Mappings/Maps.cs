using AutoMapper;
using Cars.Models;
using Project.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
        }

    }
}
