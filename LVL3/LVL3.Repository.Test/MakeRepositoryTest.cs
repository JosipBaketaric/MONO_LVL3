using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.Repository.Common;
using LVL3.Model.DomainModels;
using LVL3.Repository.Repositorys;
using LVL3.DAL;
using System.Threading.Tasks;
using Nito.AsyncEx.UnitTests;
using LVL3.Model.Common.IDomain;
using LVL3.MVCApi.AutoMapperConfig;
using Moq;

namespace LVL3.Repository.Test
{
     [TestClass]
    public class MakeRepositoryTest
    {

        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            IncludeAllMappings.include();
            var vMake = new VehicleMakeDomain() { Name = "testName", Abrv = "testAbrv", VehicleMakeId = Guid.NewGuid(), VehicleModel = null };
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new MakeRepository(repository);
            //Act
            Task.Run(async () =>
            {
                var result = await testRepository.Add(vMake);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();

        }
       


    }
}
