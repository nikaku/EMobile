

using EMobile.BL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMobile.DB
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<MobileSpec> MobileSpecs { get; set; }
    }
}
