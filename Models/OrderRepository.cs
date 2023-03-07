using Microsoft.EntityFrameworkCore;

namespace Capstone1.Models

{
    public class OrderRepository : IOrderRepository
    {
        private SweetDBContext _dbContext;

        public OrderRepository(SweetDBContext sweetDBContext)
        {
            _dbContext = sweetDBContext;
        }
        public IQueryable<Order> GetAll => _dbContext.Orders
                                         .Include(o => o.CartObjects)
                                          .ThenInclude(b => b.Service);

                            
        public void SaveOrder(Order order)
        {
            _dbContext.AttachRange(order.CartObjects.Select(b=>b.Service));
            if(order.OrderID == 0)
            {
                _dbContext.Orders.Add(order);
            }
            _dbContext.SaveChanges();
        }
    }
}
