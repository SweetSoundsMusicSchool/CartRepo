namespace Capstone1.Infrastructure
{
    public class PageInformation
    {
        public int TotalServiceAvailable { get; set; }

        public int ServicePerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages =>
           (int)Math.Ceiling((decimal)TotalServiceAvailable / ServicePerPage);
    }
}
