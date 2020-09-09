namespace Project.Service.Helpers
{
    public interface IPagingParameters
    {
        int? PageNumber { get; set; }
        int? PageSize { get; set; }
    }
}