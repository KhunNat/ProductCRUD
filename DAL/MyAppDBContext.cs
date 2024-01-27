
using CRUDWithWebAPI.Model;
using Microsoft.EntityFrameworkCore;
namespace CRUDWithWebAPI.DAL
{
    public class MyAppDBContext : DbContext

    {
        public MyAppDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}



