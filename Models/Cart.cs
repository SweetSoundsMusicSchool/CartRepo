using System.ComponentModel.DataAnnotations;

namespace Capstone1.Models
{
    public class Cart
    {
        public List<CartObject> ListCartObjects { get; set; } = new List<CartObject>();
      
        public virtual void AddItems(Service service, int quantity)
        {
            CartObject? cartObject =  ListCartObjects
                .Where(b=>b.Service.ServiceID == service.ServiceID) 
                .FirstOrDefault();

            if (cartObject == null)
            {
                ListCartObjects.Add(new CartObject
                {
                    Service= service,
                    Quantity= quantity
                });
            }
            else
            {
                cartObject.Quantity += quantity;
            }
        }

        
        public virtual void RemoveService(Service service)
        {
            ListCartObjects.RemoveAll(l=>l.Service.ServiceID == service.ServiceID);
        }

        public decimal TotalPrice()=>
            ListCartObjects.Sum(c=>c.Service.Price * c.Quantity);

        public virtual void Clear()=>ListCartObjects.Clear();
    }

    public class CartObject
    {
        [Key]
        public int CartObjID { get; set; }

        public Service Service { get; set; }

        public int Quantity { get; set; }
    }
}
