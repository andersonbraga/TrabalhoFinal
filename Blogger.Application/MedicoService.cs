using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Domain;
using Blogger.Infra;

namespace Blogger.Application
{
    public class MedicoService : IMedicoService
    {
        private IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public Medico Create(Medico medico)
        {
            Validator.Validate(medico);

            var savedMedico = _medicoRepository.Save(medico);

            return savedMedico;
        }


        public Medico Retrieve(int id)
        {
            return _medicoRepository.Get(id);
        }


        public Medico Update(Medico medico)
        {
            Validator.Validate(medico);

            var updatedMedico = _medicoRepository.Update(medico);

            return updatedMedico;
        }


        public Medico Delete(int id)
        {
            return _medicoRepository.Delete(id);
        }


        public List<Medico> RetrieveAll()
        {
            return _medicoRepository.GetAll();
        }
    }
}
