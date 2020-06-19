using BSalonWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BSalonWebApp.Data
{
    public class BSalonDbContext : DbContext
    {
        public DbSet<WorkDay> WorkDays { get; set; }

        public BSalonDbContext(DbContextOptions<BSalonDbContext> options) : base(options)
        {

        }
    }
}
