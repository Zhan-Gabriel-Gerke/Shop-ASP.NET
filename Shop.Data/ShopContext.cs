using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;

namespace Shop.Data
{
    public class ShopContext : DbContext
    {
       public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        protected ShopContext()
        {
        }

        public DbSet<SpaceShip> SpaceShips { get; set; }
    }
}
