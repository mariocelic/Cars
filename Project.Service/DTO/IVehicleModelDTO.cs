namespace Project.Service.DTO
{
    public interface IVehicleModelDTO
    {
        string Abrv { get; set; }
        int MakeId { get; set; }
        int ModelId { get; set; }
        string Name { get; set; }
        VehicleMakeDTO VehicleMake { get; set; }
    }
}