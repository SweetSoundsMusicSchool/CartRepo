using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Controllers
{
    public class OrderController : Controller
    {
        
        private IOrderRepository _orderRepository;
        private Cart cart;
   
        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            this.cart = cart;
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.ListCartObjects.Count == 0)
            {
                ModelState.AddModelError("", "Cart Empty");
            }
            if(ModelState.IsValid)
            {
                order.CartObjects= cart.ListCartObjects.ToArray();
                _orderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Complete", new {orderId = order.OrderID});
            }

            else
            {
                return View();
            }
        }


        
        }
    }

