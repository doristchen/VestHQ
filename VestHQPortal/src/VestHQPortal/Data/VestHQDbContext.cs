using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VestHQModel;

namespace VestHQPortal.Data
{
    public class VestHQDbContext : DbContext
    {
        public VestHQDbContext(DbContextOptions<VestHQDbContext> options) :
            base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPriceHistory> StockPriceHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>().ToTable("Employer");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Holding>().ToTable("Holding");
            modelBuilder.Entity<StockPriceHistory>().ToTable("StockPriceHistory");
            
            modelBuilder.Entity<StockPriceHistory>(entity =>
            {
                entity.HasKey(e => e.Id)
                .ForSqlServerIsClustered(false);

                /* Create Clustered Index on StockPriceHistory*/

                entity.HasIndex(e => new { e.StockId, e.Date })
                     .IsUnique()
                     .ForSqlServerIsClustered(true)
                     .HasName("IX_StockPriceHistory_StockDate");
            });
         }
    }
}
