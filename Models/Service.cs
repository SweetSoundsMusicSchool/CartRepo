using System.ComponentModel.DataAnnotations.Schema;

namespace  Capstone1.Models

{
    public class Service
    {
        public int ServiceID { get; set; }

        public string ServiceName { get; set; }    = string.Empty;

        [Column(TypeName ="decimal(8,2)")]
        public decimal Price { get; set; } 

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;


    }
}
