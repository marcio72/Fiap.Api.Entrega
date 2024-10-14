using Fiap.Api.Entrega.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Entrega.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<AgendaModel> Agendamentos { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaModel>(entity =>
            {
                entity.ToTable("Tbl_Agenda");
                entity.HasKey(e => e.AgendaId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Logradouro).IsRequired();
                entity.Property(e => e.DataAgenda).HasColumnType("date");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
