using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Context
{
    public class KretaMySqlContext : KretaContext
    {
        public KretaMySqlContext(DbContextOptions<KretaMySqlContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
