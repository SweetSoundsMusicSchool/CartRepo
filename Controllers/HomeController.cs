using Capstone1.Infrastructure;
using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Controllers
{
    public class HomeController : Controller
    {
        private ISweetRepository _sweetRepository;

        //how many items you want to show in each page
        public int ServicePP = 2;

        public HomeController(ISweetRepository sweetRepository)
        {
            _sweetRepository = sweetRepository;
        }
        public IActionResult Index(string category, int currentPage=1)
        {
            return View(new ServicesList
            {
                Services = _sweetRepository.GetAllService
                .Where(x =>category == null || x.Category == category)
                .OrderBy(b => b.ServiceID)
                .Skip((currentPage - 1) * ServicePP)
                .Take(ServicePP),
                PageInfo = new PageInformation
                {
                    ServicePerPage = ServicePP,
                    CurrentPage = currentPage,
                    TotalServiceAvailable = category == null ?
                    _sweetRepository.GetAllService.Count() :
                    _sweetRepository.GetAllService.Where(b=>
                    b.Category == category).Count()
                },
                CurrentCategory = category
            });
        }
                
                
               
        }
    }

