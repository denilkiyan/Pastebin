using Microsoft.EntityFrameworkCore;
using Pastbin.Models;

namespace Pastbin.DBContext
{
    public class PastebinContext:DbContext
    {
        public DbSet<Record> Records { get; set; }
        public PastebinContext(DbContextOptions<PastebinContext> options):base(options) => Database.EnsureCreated();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

        
            
        
