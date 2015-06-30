using System;
using System.Data.Entity;
using Blogger.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogger.Infra.Data;
using FluentAssertions;

namespace Blogger.Test
{
    [TestClass]
    public class MedicoRepositoryTest
    {
        private MedicoContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<MedicoContext>());

            _contextForTest = new MedicoContext();
            _contextForTest.Medicos.Add(ObjectMother.GetMedico());
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateMedicoRepositoryTest()
        {

            Medico b = ObjectMother.GetMedico();
            IMedicoRepository repository = new MedicoRepository();

            //Action
            Medico newMedico = repository.Save(b);

            //Assert
            Assert.IsTrue(newMedico.Id > 0);

        }

        [TestMethod]
        public void RetrieveMedicoRepositoryTest()
        {
            //Arrange
            IMedicoRepository repository = new MedicoRepository();

            //Action
            Medico medico = repository.Get(1);

            //Assert
            Assert.IsNotNull(medico);
            Assert.IsTrue(medico.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(medico.Nome));
            Assert.IsFalse(string.IsNullOrEmpty(medico.Especialidade));
            Assert.IsFalse(string.IsNullOrEmpty(medico.Residente));


        }

        [TestMethod]
        public void UpdateMedicoRepositoryTest()
        {
            //Arrange
            IMedicoRepository repository = new MedicoRepository();
            Medico medico = _contextForTest.Medicos.Find(1);
            medico.Nome = "Teste";
            medico.Especialidade = "Teste";
            medico.Residente = "Teste";

            //Action
            var updatedMedico = repository.Update(medico);

            //Assert
            var persistedMedico = _contextForTest.Medicos.Find(1);
            Assert.IsNotNull(updatedMedico);
            Assert.AreEqual(updatedMedico.Id, persistedMedico.Id);
            Assert.AreEqual(updatedMedico.Nome, persistedMedico.Nome);
            Assert.AreEqual(updatedMedico.Especialidade, persistedMedico.Especialidade);
            Assert.AreEqual(updatedMedico.Residente, persistedMedico.Residente);


        }

        [TestMethod]
        public void DeleteMedicoRepositoryTest()
        {
            //Arrange
            IMedicoRepository repository = new MedicoRepository();

            //Action
            var deletedMedico = repository.Delete(1);

            //Assert
            var persistedMedico = _contextForTest.Medicos.Find(1);
            Assert.IsNull(persistedMedico);


        }
    }
    

    
}
