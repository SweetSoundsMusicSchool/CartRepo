

using Microsoft.EntityFrameworkCore;

namespace Capstone1.Models
{
    public class SweetDBContext:DbContext
    {
        public SweetDBContext(DbContextOptions<SweetDBContext> dbContextOptions)
            :base(dbContextOptions) { }

        //entity -- table name too
       public DbSet<Service> Services { get; set; }  
       public DbSet<Order> Orders { get; set; }


            
    }
}
