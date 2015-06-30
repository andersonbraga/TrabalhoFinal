using Blogger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Application
{
    public interface IPacienteService
    {
        Paciente Create(Paciente paciente);
        Paciente Retrieve(int id);
        Paciente Update(Paciente paciente);
        Paciente Delete(int id);
        List<Paciente> RetrieveAll();
    }
}
