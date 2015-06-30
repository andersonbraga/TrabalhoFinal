using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogger.Domain;
using Blogger.Infra;

namespace Blogger.Test
{
    [TestClass]
    public class MedicoDomainTest
    {
        [TestMethod]
        public void CreateAMedicoTest()
        {
            Medico medico = ObjectMother.GetMedico();

            Assert.IsNotNull(medico);
        }

        [TestMethod]
        public void CreateAValidMedicoTest()
        {
            Medico medico = ObjectMother.GetMedico();

            Validator.Validate(medico);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidMedicoNameTest()
        {
            Medico medico = new Medico();

            Validator.Validate(medico);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidMedicoEspecialidadeTest()
        {
            Medico medico = new Medico();
            medico.Especialidade = "Pediatra";

            Validator.Validate(medico);
        }

        [TestMethod]

        public void CreateAInvalidMedicoTest()
        {
            Medico medico = new Medico();
            medico.Nome = "Pedro";
            medico.Especialidade = "Pediatra";
            medico.Residente = "Nossa Senhora dos Prazeres";

            Validator.Validate(medico);
        }
    }

   

    
}
