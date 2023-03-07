using Capstone1.Infrastructure;
using System.Text.Json.Serialization;

namespace Capstone1.Models
{
    public class SessionCart :  Cart
    {
        [JsonIgnore]
        public ISession? Session { get;  set; }

        public static Cart GetCart(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()
                                    .HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        public override void AddItems(Service service, int quantity)
        {
            base.AddItems(service, quantity);
            Session?.SetJson("Cart", this);
        }

        public override void RemoveService (Service service)
        {
            base.RemoveService(service);
            Session?.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Cart");
        }
    }
}
