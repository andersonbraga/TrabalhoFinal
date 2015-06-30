using Blogger.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Domain
{
    public class Paciente : IObjectValidation
    {
        public int Id { set; get; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome Inválido");
            if (string.IsNullOrEmpty(Sobrenome))
                throw new Exception("Sobrenome Inválido");

        }
    
    }
}
