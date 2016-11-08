using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.Repository.Common;
using LVL3.Model.DomainModels;
using LVL3.Repository.Repositorys;
using LVL3.DAL;
using System.Threading.Tasks;
using Nito.AsyncEx.UnitTests;
using LVL3.Model.Common.IDomain;

namespace LVL3.Repository.Test
{
     [AsyncTestClass]
    public class MakeRepositoryTest
    {
        protected VehicleMakeDomain TestObject { get; private set; }
        private MakeRepository MakeRepositroyService = new MakeRepository(new Repositorys.Repository(new VehicleContext(), new UnitOfWorkFactory(new UnitOfWork(new VehicleContext()))));

        [TestMethod]
        public async Task TestAdd()
        {
            //Arrange
            TestObject = new VehicleMakeDomain { Name = "test1", Abrv = "testAbrv", VehicleMakeId = Guid.NewGuid() };
            //Act
            var result = await MakeRepositroyService.Add(TestObject);
            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task TestGet()
        {
            //Act
            var result = await MakeRepositroyService.Get(TestObject.VehicleMakeId);
            //Assert
            Assert.AreEqual(TestObject, result);
        }

        [TestMethod]
        public async Task TestUpdate()
        {
        }

        [TestMethod]
        public async Task TestDelete()
        {
            //Act
            var result = await MakeRepositroyService.Delete(TestObject.VehicleMakeId);
            //Assert
            Assert.AreEqual(0, result);
        }


    }
}
