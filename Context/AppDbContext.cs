using Microsoft.EntityFrameworkCore;
using NossoERP.WebApi.Nuvem.Clinica.Database;

namespace NossoERP.WebApi.Nuvem.Clinica.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<cid> cid { get; set; }
    }
}
