using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.MVCApi.AutoMapperConfig;
using LVL3.DAL;
using LVL3.Repository.Repositorys;
using LVL3.Repository;
using LVL3.Model.DomainModels;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using LVL3.Model.Common.IDomain;
using System.Linq;

namespace LVL3.Service.Test
{
    [TestClass]
    public class ModelServiceTest
    {
        [TestMethod]
        public void ModelServiceAddTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testService = new ModelService(modelRepository);

            //Add make
            var vMake = new VehicleMakeDomain() { Name = "ModelServiceAddTest", Abrv = "ModelServiceAddTest", VehicleModel = null };
            Task.Run(async () =>
            {
                var response = await makeService.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            IVehicleMakeDomain targetMake = null;
            //Get make
            Task.Run(async () =>
            {
                var response = await makeService.ReadAll();
                Assert.IsNotNull(response);
                targetMake = response.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Create model
            var vModel = new VehicleModelDomain() { Name = "ModelServiceAddTest", Abrv = "ModelServiceAddTest", VehicleMakeId = targetMake.VehicleMakeId };

            //Add model
            Task.Run(async () =>
            {
                //Act
                var result = await testService.Add(vModel);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();

        }

        [TestMethod]
        public void ModelServiceReadTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testService = new ModelService(modelRepository);

            //Add make
            var vMake = new VehicleMakeDomain() { Name = "ModelServiceReadTest", Abrv = "ModelServiceReadTest", VehicleModel = null };
            Task.Run(async () =>
            {
                var response = await makeService.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            IVehicleMakeDomain targetMake = null;
            //Get make
            Task.Run(async () =>
            {
                var response = await makeService.ReadAll();
                Assert.IsNotNull(response);
                targetMake = response.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Create model
            var vModel = new VehicleModelDomain() { Name = "ModelServiceReadTest", Abrv = "ModelServiceReadTest", VehicleMakeId = targetMake.VehicleMakeId };

            //Add model
            Task.Run(async () =>
            {
                var response = await testService.Add(vModel);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Get model
            IVehicleModelDomain targetModel = null;
            Task.Run(async () =>
            {
                var response = await testService.ReadAll();
                Assert.IsNotNull(response);
                targetModel = response.LastOrDefault();
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var result = await testService.Read(targetModel.VehicleModelId);
                //Assert
                Assert.AreEqual(targetModel.VehicleModelId, result.VehicleModelId);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void ModelServiceReadAllTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testService = new ModelService(modelRepository);

            //Add make
            var vMake = new VehicleMakeDomain() { Name = "ModelServiceReadAllTest", Abrv = "ModelServiceReadAllTest", VehicleModel = null };
            Task.Run(async () =>
            {
                var response = await makeService.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            IVehicleMakeDomain targetMake = null;
            //Get make
            Task.Run(async () =>
            {
                var response = await makeService.ReadAll();
                Assert.IsNotNull(response);
                targetMake = response.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Create model
            var vModel = new VehicleModelDomain() { Name = "ModelServiceReadAllTest", Abrv = "ModelServiceReadAllTest", VehicleMakeId = targetMake.VehicleMakeId };

            //Add model
            Task.Run(async () =>
            {
                var response = await testService.Add(vModel);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var result = await testService.ReadAll();
                //Assert
                Assert.IsNotNull(result);
            }).GetAwaiter().GetResult();
        }


        [TestMethod]
        public void ModelServiceUpdateTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testService = new ModelService(modelRepository);

            //Add make
            var vMake = new VehicleMakeDomain() { Name = "ModelServiceUpdateTest", Abrv = "ModelServiceUpdateTest", VehicleModel = null };
            Task.Run(async () =>
            {
                var response = await makeService.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            IVehicleMakeDomain targetMake = null;
            //Get make
            Task.Run(async () =>
            {
                var response = await makeService.ReadAll();
                Assert.IsNotNull(response);
                targetMake = response.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Create model
            var vModel = new VehicleModelDomain() { Name = "ModelServiceUpdateTest", Abrv = "ModelServiceUpdateTest", VehicleMakeId = targetMake.VehicleMakeId };

            //Add model
            Task.Run(async () =>
            {
                var response = await testService.Add(vModel);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            IVehicleModelDomain targetModel = null;
            Task.Run(async () =>
            {
                var response = await testService.ReadAll();
                Assert.IsNotNull(response);
                targetModel = response.LastOrDefault();
            }).GetAwaiter().GetResult();

            targetModel.Name = "ModelServiceUpdateTestTested";

            Task.Run(async () =>
            {
                var result = await testService.Update(targetModel);
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();

        }        

    }
}
