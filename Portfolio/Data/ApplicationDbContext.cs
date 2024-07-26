using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Scroll> Scrolls { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var csvReaderService = new CsvReaderService();
            var scrolls = csvReaderService.GetScrollsFromCsv("Data/ScrollData.csv");
            modelBuilder.Entity<Scroll>().HasData(scrolls);
        }

    }
}
