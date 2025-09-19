using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Kindergarten;
using Shop.Core.Domain.SpaceShips;

namespace Shop.Data.SpaceShips
{
    public class ShopContext : DbContext
    {
       public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<SpaceShip> SpaceShips { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
    }
}
