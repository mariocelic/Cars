using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Service.Data
{
    public class VehicleMake
    {
        [Key]
        public int MakeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public VehicleModel VehicleModel { get; set; }


    }
}
