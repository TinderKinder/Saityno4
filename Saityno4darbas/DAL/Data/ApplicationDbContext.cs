using Microsoft.EntityFrameworkCore;
using Saityno4darbas.DAL.Models;

namespace Saityno4darbas.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=SaitynoAPI;trusted_connection=true;");
        }
    }
}