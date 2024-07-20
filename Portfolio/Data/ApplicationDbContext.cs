using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Scroll> Scrolls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var csvReaderService = new CsvReaderService();
            var scrolls = csvReaderService.GetScrollsFromCsv("Data/ScrollData.csv");
            modelBuilder.Entity<Scroll>().HasData(scrolls);
        }

    }
}
