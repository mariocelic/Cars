using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class VehicleModelDTO
    {
        public int ModelId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public VehicleMakeDTO VehicleMake { get; set; }
        public int MakeId { get; set; }

        public IEnumerable<SelectListItem> VehicleMakes { get; set; }
    }
}