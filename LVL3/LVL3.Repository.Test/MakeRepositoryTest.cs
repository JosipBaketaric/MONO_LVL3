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
using System.Collections;
using System.Collections.Generic;

namespace LVL3.Repository.Test
{
     [TestClass]
    public class MakeRepositoryTest
    {

        [TestMethod]
        public void MakeRepositoryAddTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vMake = new VehicleMakeDomain() { Name = "MakeRepositoryAddTest", Abrv = "MakeRepositoryAddTest", VehicleMakeId = Guid.NewGuid(), VehicleModel = null };
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
       
        [TestMethod]
        public void MakeRepositoryUpdateTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vMake = new VehicleMakeDomain() { Name = "MakeRepositoryUpdateTest", Abrv = "MakeRepositoryUpdateTest", VehicleMakeId = Guid.NewGuid(), VehicleModel = null };
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new MakeRepository(repository);
            int response;
            Task.Run(async () =>
            {
                response = await testRepository.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();
            vMake.Name = "MakeRepositoryUpdateTestTested";
            //Act
            Task.Run(async () =>
            {
                var result = await testRepository.Update(vMake);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void MakeRepositoryGetAllTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vMake = new VehicleMakeDomain() { Name = "MakeRepositoryGetAllTest", Abrv = "MakeRepositoryGetAllTest", VehicleMakeId = Guid.NewGuid(), VehicleModel = null };

            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new MakeRepository(repository);
            int response;
            Task.Run(async () =>
            {
                response = await testRepository.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();
            //Act
            Task.Run(async () =>
            {
                var result = await testRepository.GetAll();
                //Assert
                Assert.IsNotNull(result);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void MakeRepositoryDeleteTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vMake = new VehicleMakeDomain() { Name = "MakeRepositoryDeleteTest", Abrv = "MakeRepositoryDeleteTest", VehicleModel = null };
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new MakeRepository(repository);

            Task.Run(async () =>
            {
                var response = await testRepository.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            IEnumerable<IVehicleMakeDomain> getAll;
            Guid targetId = Guid.NewGuid();

            Task.Run(async () =>
            {
                getAll = await testRepository.GetAll();
                //Assert
                Assert.IsNotNull(getAll);
                
                foreach (var item in getAll)
                {
                    targetId = item.VehicleMakeId;
                }

                var result = await testRepository.Delete(targetId);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();      
                             
        }


        [TestMethod]
        public void MakeRepositoryGetTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vMake = new VehicleMakeDomain() { Name = "MakeRepositoryGetTest", Abrv = "MakeRepositoryGetTest", VehicleModel = null };
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new MakeRepository(repository);
            int response;
            Task.Run(async () =>
            {
                response = await testRepository.Add(vMake);
                //Assert.AreEqual(1, response);               
            }).GetAwaiter().GetResult();

            IEnumerable<IVehicleMakeDomain> getAll;
            IVehicleMakeDomain targetMake = null;

            Task.Run(async () =>
            {
                getAll = await testRepository.GetAll();
                //Assert
                Assert.IsNotNull(getAll);

                foreach (var item in getAll)
                {
                    targetMake = item;
                }

                var result = await testRepository.Get(targetMake.VehicleMakeId);
                //Assert
                Assert.AreEqual(targetMake.VehicleMakeId, result.VehicleMakeId);
            }).GetAwaiter().GetResult();

        }       
        
    }
}
