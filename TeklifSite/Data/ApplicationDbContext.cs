using Microsoft.EntityFrameworkCore;
using TeklifSite.Models;

namespace TeklifSite.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Admin>?Admins { get; set; }
        public DbSet<Category>?Categories { get; set; }
        public DbSet<Sliders>?Sliders { get; set; }  
        public DbSet<Carts>? Carts { get; set; }
        public DbSet<Offers>? Offers { get; set; }
        public DbSet<Products>?Products { get; set; }
        public DbSet<Customers>? Customers { get; set; }
    }
}
