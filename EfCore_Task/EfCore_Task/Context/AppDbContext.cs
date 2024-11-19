using EfCore_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore_Task.Context
{
    public  class AppDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER=DESKTOP-9OJ3NSG\\SQLEXPRESS;DATABASE=EFCore;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder); 
        }

    }
}
