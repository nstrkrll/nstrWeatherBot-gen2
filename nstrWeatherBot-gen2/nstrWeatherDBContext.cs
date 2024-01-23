using Microsoft.EntityFrameworkCore;

namespace nstrWeatherBot_gen2
{
    public class nstrWeatherDBContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.ApiKeys> ApiKeys { get; set; }

        public nstrWeatherDBContext(DbContextOptions<nstrWeatherDBContext> options) : base(options) { }
    }
}