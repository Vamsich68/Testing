
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Testing.Models;

namespace Testing.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            //optionsBuilder.UseSqlServer("myrealconnectionstring");
        }

        public DbSet<Employee> Employees { get; set; }
    }

    

}
