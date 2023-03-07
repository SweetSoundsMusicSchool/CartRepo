using Capstone1.Models;
namespace Capstone1.Infrastructure
{
    public class ServicesList
    {
        public IEnumerable<Service> Services { get; set; }
        public PageInformation PageInfo { get; set; }
        public string CurrentCategory { get; set; }



    }
}
