using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogger.Infra.Data;
using System.Data.Entity;
using Blogger.Domain;
using Blogger.Infra;

namespace Blogger.Test
{
    [TestClass]
    public class PacienteRepositoryTest
    {
        private PacienteContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<PacienteContext>());

            _contextForTest = new PacienteContext();
            _contextForTest.Pacientes.Add(ObjectMother.GetPaciente());
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreatePacienteRepositoryTest()
        {

            Paciente b = ObjectMother.GetPaciente();
            IPacienteRepository repository = new PacienteRepository();

            //Action
            Paciente newPaciente = repository.Save(b);

            //Assert
            Assert.IsTrue(newPaciente.Id > 0);

           

        }

        [TestMethod]
        public void RetrievePacienteRepositoryTest()
        {
            //Arrange
            IPacienteRepository repository = new PacienteRepository();

            //Action
            Paciente paciente = repository.Get(1);

            //Assert
            Assert.IsNotNull(paciente);
            Assert.IsTrue(paciente.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(paciente.Nome));
            Assert.IsFalse(string.IsNullOrEmpty(paciente.Sobrenome));

            Validator.Validate(paciente);

           
        }

        [TestMethod]
        public void UpdatePacienteRepositoryTest()
        {
            //Arrange
            IPacienteRepository repository = new PacienteRepository();
            Paciente paciente = _contextForTest.Pacientes.Find(1);
            paciente.Nome = "Teste";
            paciente.Sobrenome = "Teste";
        

            //Action
            var updatedPaciente = repository.Update(paciente);

            //Assert
            var persistedPaciente = _contextForTest.Pacientes.Find(1);
            Assert.IsNotNull(updatedPaciente);
            Assert.AreEqual(updatedPaciente.Id, persistedPaciente.Id);
            Assert.AreEqual(updatedPaciente.Nome, persistedPaciente.Nome);
            Assert.AreEqual(updatedPaciente.Sobrenome, persistedPaciente.Sobrenome);
          

            Validator.Validate(paciente);
        }

        [TestMethod]
        public void DeletePacienteRepositoryTest()
        {
            //Arrange
            IPacienteRepository repository = new PacienteRepository();

            //Action
            var deletedPaciente = repository.Delete(1);

            //Assert
            var persistedPaciente = _contextForTest.Pacientes.Find(1);
            Assert.IsNull(persistedPaciente);

       
        }
    }
}
