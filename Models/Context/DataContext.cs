
using Microsoft.EntityFrameworkCore;

namespace EFCorePostgreSQL.Models.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }    
    }
}
