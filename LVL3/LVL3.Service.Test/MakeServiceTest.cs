using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.MVCApi.AutoMapperConfig;
using LVL3.DAL;
using LVL3.Repository;
using LVL3.Repository.Repositorys;
using LVL3.Model.DomainModels;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using LVL3.Model.Common.IDomain;
using System.Linq;

namespace LVL3.Service.Test
{
    [TestClass]
    public class MakeServiceTest
    {
        [TestMethod]
        public void MakeServiceAddTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var vMake = new VehicleMakeDomain() { Name = "MakeRepositoryAddTest", Abrv = "MakeRepositoryAddTest", VehicleModel = null };
            var testService = new MakeService(makeRepository, modelRepository);
            
            Task.Run(async () =>
            {
                //Act
                var result = await testService.Add(vMake);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void MakeServiceDeleteTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var vMake = new VehicleMakeDomain() { Name = "MakeServiceDeleteTest", Abrv = "MakeServiceDeleteTest", VehicleModel = null };
            var testService = new MakeService(makeRepository, modelRepository);

            IEnumerable<IVehicleMakeDomain> readAll = null;
            IVehicleMakeDomain targetItem = null;
            Task.Run(async () =>
            {
                readAll = await testService.ReadAll();
                Assert.IsNotNull(readAll);
                targetItem = readAll.LastOrDefault();
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var result = await testService.Delete(targetItem.VehicleMakeId);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();

        }

        [TestMethod]
        public void MakeServiceReadTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var vMake = new VehicleMakeDomain() { Name = "MakeServiceReadTest", Abrv = "MakeServiceReadTest", VehicleModel = null };
            var testService = new MakeService(makeRepository, modelRepository);

            IEnumerable<IVehicleMakeDomain> readAll = null;
            IVehicleMakeDomain targetItem = null;
            Task.Run(async () =>
            {
                readAll = await testService.ReadAll();
                Assert.IsNotNull(readAll);
                targetItem = readAll.LastOrDefault();
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var result = await testService.Read(targetItem.VehicleMakeId);
                //Assert
                Assert.AreEqual(targetItem.VehicleMakeId, result.VehicleMakeId);
            }).GetAwaiter().GetResult();

        }

        [TestMethod]
        public void MakeServiceReadAllTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var testService = new MakeService(makeRepository, modelRepository);

            Task.Run(async () =>
            {
                //Act
                var result = await testService.ReadAll();
                //Assert
                Assert.IsNotNull(result);

            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void MakeServiceUpdateTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var vMake = new VehicleMakeDomain() { Name = "MakeServiceReadTest", Abrv = "MakeServiceReadTest", VehicleModel = null };
            var testService = new MakeService(makeRepository, modelRepository);

            IEnumerable<IVehicleMakeDomain> readAll = null;
            IVehicleMakeDomain targetItem = null;
            Task.Run(async () =>
            {
                readAll = await testService.ReadAll();
                Assert.IsNotNull(readAll);
                targetItem = readAll.LastOrDefault();
            }).GetAwaiter().GetResult();

            targetItem.Name = "MakeServiceReadTestTested";
            Task.Run(async () =>
            {
                //Act
                var result = await testService.Update(targetItem);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();

        }


    }
}
