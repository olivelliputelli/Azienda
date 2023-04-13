using Microsoft.EntityFrameworkCore;

namespace Azienda.Shared
{
    public class AziendaDbContext : DbContext
    {
        public DbSet<Dipartimento> Dipartimenti { get; set; } 
        public DbSet<ImpiegatoEta> ImpiegatiEta { get; set; } 

        public AziendaDbContext(DbContextOptions<AziendaDbContext> options)
    : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImpiegatoEta>()
                .ToView("ImpiegatiEtaVista");
        }
    }
}
