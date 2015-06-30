using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Domain;

namespace Blogger.Application
{
    public interface IMedicoService
    {
        Medico Create(Medico medico);
        Medico Retrieve(int id);
        Medico Update(Medico medico);
        Medico Delete(int id);
        List<Medico> RetrieveAll();
    }
}
