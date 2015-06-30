using Blogger.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Infra.Data
{
    public class PacienteRepository : IPacienteRepository
    {
        private PacienteContext context;

        public PacienteRepository()
        {
            context = new PacienteContext();
        }

        public Paciente Save(Paciente paciente)
        {
            var newPaciente = context.Pacientes.Add(paciente);
            context.SaveChanges();
            return newPaciente;
        }


        public Paciente Get(int id)
        {
            var paciente = context.Pacientes.Find(id);
            return paciente;
        }


        public Paciente Update(Paciente paciente)
        {
            DbEntityEntry entry = context.Entry(paciente);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return paciente;
        }


        public Paciente Delete(int id)
        {
            var paciente = context.Pacientes.Find(id);
            DbEntityEntry entry = context.Entry(paciente);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return paciente;
        }


        public List<Paciente> GetAll()
        {
            return context.Pacientes.ToList();
        }
    }
}
