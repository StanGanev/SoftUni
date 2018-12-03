using Microsoft.EntityFrameworkCore;
using SoftUniAirlines.Models;

namespace SoftUniAirlines.Data
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=softuni_airlines_asp;user=root;Sslmode=none");
            }
        }
    }
}
