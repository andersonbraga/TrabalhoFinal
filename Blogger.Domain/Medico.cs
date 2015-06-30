using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Infra;

namespace Blogger.Domain
{
    public class Medico : IObjectValidation
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public int CRM { get; set; }

        public string Residente { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome Inválido");
            if (string.IsNullOrEmpty(Residente))
                throw new Exception("Residente Inválido");

        }
    }
}
