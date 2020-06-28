using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.EntityFrameworkCore;

namespace BSalonWebApp.Data
{
    public class BSalonDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        public DbSet<Service> Services { get; set; }

        public BSalonDbContext(DbContextOptions<BSalonDbContext> options) : base(options)
        { }
    }
}
