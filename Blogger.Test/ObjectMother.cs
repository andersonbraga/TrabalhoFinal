using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Domain;

namespace Blogger.Test
{
    public class ObjectMother
    {
        public static Medico GetMedico()
        {
            Medico medico = new Medico();
            medico.Nome = "Pedro";
            medico.Especialidade = "Pediatra";
            medico.Residente = "Nossa Senhora dos Prazeres";



            return medico;
        }

        public static Paciente GetPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.Nome = "Joao";
            paciente.Sobrenome = "Silva";
           



            return paciente;
        }

    }

    
}
