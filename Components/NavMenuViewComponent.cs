using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Components
{
    public class NavMenuViewComponent : ViewComponent
    {
        private ISweetRepository sweetRepository;

        public NavMenuViewComponent(ISweetRepository sweetRepository)
        {
            this.sweetRepository = sweetRepository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData.Values["category"];
            return View(sweetRepository.GetAllService
                .Select(x=>x.Category)
                .Distinct()
                .OrderBy(x=>x));
        }
    }
}
