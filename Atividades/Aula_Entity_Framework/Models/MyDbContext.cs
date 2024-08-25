using Microsoft.EntityFrameworkCore;

namespace Aula_Entity_Framework.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(
           DbContextOptions<MyDbContext> options
           ) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
