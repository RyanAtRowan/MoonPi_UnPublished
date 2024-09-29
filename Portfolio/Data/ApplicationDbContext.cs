using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Data
{
    /// <summary>
    /// Application database context for managing Identity, Scrolls, Favorites, and users.
    /// Inherits from IdentityDbContext to handle ASP.NET Identity user management.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Constructor that passes options to the base DbContext.
        /// </summary>
        /// <param name="options">Options for configuring the DbContext, such as connection strings.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// DbSet for Scroll entities.
        /// </summary>
        public DbSet<Scroll> Scrolls { get; set; }

        /// <summary>
        /// DbSet for Favorite entities.
        /// </summary>
        public DbSet<Favorite> Favorites { get; set; }

        /// <summary>
        /// DbSet for custom ApplicationUser entities (if extending IdentityUser).
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        /// <summary>
        /// Configures the model and seeds initial scroll data from a CSV file.
        /// </summary>
        /// <param name="modelBuilder">The ModelBuilder used to configure the entity models.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Initialize CsvReaderService to read scroll data from a CSV file.
            var csvReaderService = new CsvReaderService();
            var scrolls = csvReaderService.GetScrollsFromCsv("Data/ScrollData.csv");

            // Seed the scroll data into the Scrolls DbSet.
            modelBuilder.Entity<Scroll>().HasData(scrolls);
        }

    }
}
