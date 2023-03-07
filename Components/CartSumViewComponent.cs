using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Components
{
    public class CartSumViewComponent : ViewComponent
    {
        private Cart Cart;
        public CartSumViewComponent(Cart service)
        {
            Cart = service;
        }

        public IViewComponentResult Invoke()
        {
            return View(Cart);
        }
    }
}
