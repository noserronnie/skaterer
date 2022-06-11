using Microsoft.EntityFrameworkCore;
using Skaterer.Models;

namespace Skaterer.Data
{
    public class SkatererContext : DbContext
    {
        public SkatererContext(DbContextOptions<SkatererContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<DeckProduct> DeckProduct { get; set; }

        public DbSet<TrucksProduct> TrucksProduct { get; set; }

        public DbSet<WheelsProduct> WheelsProduct { get; set; }

        public DbSet<GriptapeProduct> GriptapeProduct { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Skaterer.Models.Rating> Rating { get; set; }
    }
}
