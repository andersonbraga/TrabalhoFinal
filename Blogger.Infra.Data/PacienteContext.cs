using Blogger.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Infra.Data
{
    public class PacienteContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().ToTable("TBPaciente");
            modelBuilder.Entity<Paciente>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(255);


        }

    }
}
