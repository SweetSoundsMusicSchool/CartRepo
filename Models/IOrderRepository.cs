 namespace Capstone1.Models

{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll { get; }

        void SaveOrder(Order order);    

    }
}
