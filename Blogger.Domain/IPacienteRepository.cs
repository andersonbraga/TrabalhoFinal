using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Domain
{
    public interface IPacienteRepository
    {
        Paciente Save(Paciente paciente);
        Paciente Get(int id);
        Paciente Update(Paciente paciente);
        Paciente Delete(int i);
        List<Paciente> GetAll();
    }
}
