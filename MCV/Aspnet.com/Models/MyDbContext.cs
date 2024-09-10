using Microsoft.EntityFrameworkCore;

namespace Aspnet.com.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) 
        { }
        public DbSet <Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
