using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.DTO
{
    public class VehicleMakeDTO : IVehicleMakeDTO
    {
        public int MakeId { get; set; }

        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
