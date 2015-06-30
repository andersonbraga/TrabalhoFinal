using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogger.Domain;
using Blogger.Infra;

namespace Blogger.Test
{
    [TestClass]
    public class PacienteServiceTest
    {
        [TestMethod]
        public void CreateAPacienteTest()
        {
            Paciente paciente = ObjectMother.GetPaciente();

            Assert.IsNotNull(paciente);

            Validator.Validate(paciente);
        }

     

     

        [TestMethod]
        [ExpectedException(typeof(Exception))]        
        public void CreateAInvalidPacienteNomeTest()
        {
            Paciente paciente = new Paciente();
            paciente.Nome = "Joao";

            Validator.Validate(paciente);
            
        }

        [TestMethod]

        public void CreateAInvalidPacienteTest()
        {
            Paciente paciente = new Paciente();
            paciente.Nome = "Pedro";
            paciente.Sobrenome = "Silva";
            

            Validator.Validate(paciente);
        }
    }
    
}
