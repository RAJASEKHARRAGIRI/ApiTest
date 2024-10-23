using ApiTest.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Entity
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
