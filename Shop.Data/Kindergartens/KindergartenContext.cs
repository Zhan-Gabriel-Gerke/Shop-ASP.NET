using Microsoft.EntityFrameworkCore;
using Shop.Core.Dto.Kindergarten;
using Shop.Core.Domain.Kindergarten; // Ensure Kindergarten class is in this namespace

namespace Shop.Data.Kindergarten
{
    public class KindergartenContext : DbContext
    {
       public KindergartenContext(DbContextOptions<KindergartenContext> options)
            : base(options)
        {
        }

        public DbSet<Shop.Core.Domain.Kindergartens.Kindergarten> Kindergartens { get; set; }
        public DbSet<FileToApiKindergarten> FileToApis { get; set; }
    }
}
