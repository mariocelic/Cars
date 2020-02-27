using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels
{
    public class VehicleMakeVM
    {
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }        
        public string Abrv { get; set; }

        public VehicleModelVM VehicleModel { get; set; }
    }
}
