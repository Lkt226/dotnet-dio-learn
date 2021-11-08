using Microsoft.EntityFrameworkCore;
using FirstWebNet.Models;

namespace FirstWebNet.Models
{
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Category> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FirstWebNet;Trusted_Connection=True;");
        }

        public DbSet<FirstWebNet.Models.Product> Product { get; set; }
    }
}