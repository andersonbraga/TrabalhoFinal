using Blogger.Domain;
using Blogger.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Application
{
    public class PacienteService : IPacienteService
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public Paciente Create(Paciente paciente)
        {
           

            var savedPaciente = _pacienteRepository.Save(paciente);

            return savedPaciente;
        }


        public Paciente Retrieve(int id)
        {
            return _pacienteRepository.Get(id);
        }


        public Paciente Update(Paciente paciente)
        {
            

            var updatedPaciente = _pacienteRepository.Update(paciente);

            return updatedPaciente;
        }


        public Paciente Delete(int id)
        {
            return _pacienteRepository.Delete(id);
        }


        public List<Paciente> RetrieveAll()
        {
            return _pacienteRepository.GetAll();
        }
    }
}
