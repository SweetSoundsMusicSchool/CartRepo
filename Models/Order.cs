using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone1.Models

{
    public class Order
    {
        [Key]
        public int OrderID { get; set; } 
        public ICollection<CartObject> CartObjects { get; set; } = new List<CartObject>();
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
