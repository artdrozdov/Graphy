using Graphy.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Graphy.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        
        public DbSet<StockRecord> Stocks { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}