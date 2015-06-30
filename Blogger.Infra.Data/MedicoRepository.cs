using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Domain;

namespace Blogger.Infra.Data
{
    public class MedicoRepository : IMedicoRepository
    {
        private MedicoContext context;

        public MedicoRepository()
        {
            context = new MedicoContext();
        }

        public Medico Save(Medico medico)
        {
            var newMedico = context.Medicos.Add(medico);
            context.SaveChanges();
            return newMedico;
        }


        public Medico Get(int id)
        {
            var medico = context.Medicos.Find(id);
            return medico;
        }


        public Medico Update(Medico medico)
        {
            DbEntityEntry entry = context.Entry(medico);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return medico;
        }


        public Medico Delete(int id)
        {
            var medico = context.Medicos.Find(id);
            DbEntityEntry entry = context.Entry(medico);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return medico;
        }

        
        public List<Medico> GetAll()
        {
            return context.Medicos.ToList();
        }
        

 
    }
}
