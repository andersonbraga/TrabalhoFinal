using System.Data.Entity;
using Blogger.Domain;

namespace Blogger.Infra.Data
{
    public class MedicoContext : DbContext
    {
        public DbSet<Medico> Medicos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().ToTable("TBMedico");
            modelBuilder.Entity<Medico>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(255);


        }

    }
}