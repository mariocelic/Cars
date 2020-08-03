namespace Project.Service.Helpers
{
    public interface IPagingParameters
    {
        public int PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}