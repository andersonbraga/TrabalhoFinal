using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Domain
{
    public interface IMedicoRepository
    {
        Medico Save(Medico medico);
        Medico Get(int id);
        Medico Update(Medico medico);
        Medico Delete(int i);
        List<Medico> GetAll();
    }
}
