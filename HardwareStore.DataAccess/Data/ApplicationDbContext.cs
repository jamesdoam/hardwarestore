using Microsoft.EntityFrameworkCore;
using HardwareStore.Models;

namespace HardwareStore.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Finish> Finishes { get; set; }
    }
}


