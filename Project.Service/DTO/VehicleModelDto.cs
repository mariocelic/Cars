using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.DTO
{
    public class VehicleModelDTO : IVehicleModelDTO
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public int MakeId { get; set; }
        public VehicleMakeDTO VehicleMake { get; set; }

    }
}
