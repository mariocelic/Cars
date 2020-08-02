using Project.Service.Data;

namespace Project.Service.DTO
{
    public class VehicleModelDto
    {
        public int ModelId { get; set; }        
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
