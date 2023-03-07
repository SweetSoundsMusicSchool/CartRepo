using Capstone1.Infrastructure;
using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Capstone1.Pages
{
    public class CartModel : PageModel
    {
        private ISweetRepository sweetRepository;
        public CartModel(ISweetRepository sweetRepository, Cart cartService)
        {
            this.sweetRepository = sweetRepository;
            Cart = cartService; 
        }
        public Cart Cart { get; set; }
       public  string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("tempcart") ?? new Cart();
        }
        public IActionResult OnPost(long serviceID, string returnUrl)
        {
            Service? service = sweetRepository.GetAllService.FirstOrDefault(b=>b.ServiceID == serviceID);
            //Cart = HttpContext.Session.GetJson<Cart>("tempcart") ?? new Cart();
            if(service!=null)
            Cart.AddItems(service, 1);
            //HttpContext.Session.SetJson("tempcart", Cart);
            return RedirectToPage(new { returnUrl  = returnUrl});

        }
        public IActionResult OnPostRemove(long serviceID, string returnUrl)
        {
            Cart.RemoveService(Cart.ListCartObjects.First(c => c.Service.ServiceID == serviceID).Service);
            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }
}
