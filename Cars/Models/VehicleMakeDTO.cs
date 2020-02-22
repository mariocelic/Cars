using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class VehicleMakeDTO
    {
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public VehicleModelDTO VehicleModel { get; set; }
    }
}
