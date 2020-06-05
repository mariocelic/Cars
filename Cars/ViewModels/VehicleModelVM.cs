
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Service.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels
{
    public class VehicleModelVM
    {
        public int ModelId { get; set; }
        [Required]
        [Display (Name="Vehicle Model")]
        public string Name { get; set; }
        public string Abrv { get; set; }

        [Display(Name = "Vehicle Make")]
        public int MakeId { get; set; }
        public VehicleMakeVM VehicleMake { get; set; }
        
        
        public IEnumerable<SelectListItem> VehicleMakeList { get; set; }
                
        
    }
}