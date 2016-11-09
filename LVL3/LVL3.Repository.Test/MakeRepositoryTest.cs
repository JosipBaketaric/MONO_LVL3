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

        [TestMethod]
        public async Task TestAdd()
        {
            //Arrange
            VehicleMakeDomain testObject = new VehicleMakeDomain() { Name = "testName", Abrv = "testAbrv", VehicleMakeId = Guid.NewGuid(), VehicleModel = null };
            DependencyResolver.AutoMapperConfig.MappingConfig.RegisterMaps();
            MakeRepository makeRepositroyService = new MakeRepository(new Repositorys.Repository(new VehicleContext(), new UnitOfWorkFactory(new UnitOfWork(new VehicleContext()))));
            //Act
            var result = await makeRepositroyService.Add(testObject);
            //Assert
            Assert.AreEqual(1, result);
        }
       


    }
}
