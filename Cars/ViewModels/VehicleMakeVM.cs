using Project.Service.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cars.ViewModels
{
    public class VehicleMakeVM
    {
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }        
        public string Abrv { get; set; }        

    }
}
