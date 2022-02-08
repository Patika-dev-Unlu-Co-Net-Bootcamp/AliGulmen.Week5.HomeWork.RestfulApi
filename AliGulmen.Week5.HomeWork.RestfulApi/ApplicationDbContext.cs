using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AliGulmen.Week5.HomeWork.RestfulApi
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Container> Containers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rotation> Rotations { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Uom> Uoms { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
