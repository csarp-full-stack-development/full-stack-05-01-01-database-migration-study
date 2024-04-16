using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Context
{
    public class KretaMySqlContext : KretaContext
    {
        public KretaMySqlContext(DbContextOptions options) : base(options)
        {
        }
    }
}
