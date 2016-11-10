using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.MVCApi.AutoMapperConfig;
using LVL3.Model.DomainModels;
using LVL3.DAL;
using LVL3.Repository.Repositorys;
using System.Threading.Tasks;
using System.Collections.Generic;
using LVL3.Model.Common.IDomain;

namespace LVL3.Repository.Test
{
    [TestClass]
    public class ModelRepositoryTest
    {
        [TestMethod]
        public void ModelRepositoryAddTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vModel = new VehicleModelDomain() { Name = "ModelRepositoryAddTest", Abrv = "ModelRepositoryAddTest", VehicleModelId = Guid.NewGuid(), VehicleMakeId = Guid.Parse("03f3a155-c7a2-e611-9c16-b88687075332") };
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new ModelRepository(repository);
            //Act
            Task.Run(async () =>
            {
                var result = await testRepository.Add(vModel);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();

        }

        [TestMethod]
        public void ModelRepositoryUpdateTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vModel = new VehicleModelDomain() { Name = "ModelRepositoryUpdateTest", Abrv = "ModelRepositoryUpdateTest", VehicleModelId = Guid.NewGuid(), VehicleMakeId = Guid.Parse("03f3a155-c7a2-e611-9c16-b88687075332") };
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new ModelRepository(repository);
            
            Task.Run(async () =>
            {
                var response = await testRepository.Add(vModel);

                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            vModel.Name = "ModelRepositoryUpdateTestUpdated";

            //Act
            Task.Run(async () =>
            {
                var result = await testRepository.Update(vModel);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void ModelRepositoryGetAllTest()
        {
            //Arrange
            IncludeAllMappings.include();
            var vModel = new VehicleModelDomain() { Name = "ModelRepositoryUpdateTest", Abrv = "ModelRepositoryUpdateTest", VehicleModelId = Guid.NewGuid(), VehicleMakeId = Guid.Parse("03f3a155-c7a2-e611-9c16-b88687075332") };
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new ModelRepository(repository);

            Task.Run(async () =>
            {
                var response = await testRepository.Add(vModel);

                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Act
            Task.Run(async () =>
            {
                var result = await testRepository.Add(vModel);
                //Assert
                Assert.IsNotNull(result);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void ModelRepositoryGetTest()
        {
            //Arrange
            //Init repo
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new ModelRepository(repository);
            var makeRepository = new MakeRepository(repository);

            //Create maker
            var vMake = new VehicleMakeDomain() { Name = "ModelRepositoryGetTest", Abrv = "ModelRepositoryGetTest" };
            Task.Run(async () =>
            {
                var response = await makeRepository.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Get maker
            IEnumerable<IVehicleMakeDomain> getAllMakers = null;
            IVehicleMakeDomain targetMaker = null;
            Task.Run(async () =>
            {
                getAllMakers = await makeRepository.GetAll();
                Assert.IsNotNull(getAllMakers);

                foreach (var item in getAllMakers)
                {
                    targetMaker = item;
                }
            }).GetAwaiter().GetResult();

            //Create model
            var vModel = new VehicleModelDomain() { Name = "ModelRepositoryGetTest", Abrv = "ModelRepositoryGetTest", VehicleMakeId = targetMaker.VehicleMakeId };

            //Add model
            Task.Run(async () =>
            {
                var response = await testRepository.Add(vModel);

                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Get model
            IEnumerable<IVehicleModelDomain> getAll;
            IVehicleModelDomain targetModel = null;

            Task.Run(async () =>
            {
                getAll = await testRepository.GetAll();
                Assert.IsNotNull(getAll);

                foreach (var item in getAll)
                {
                    targetModel = item;
                }

                var result = await testRepository.Get(targetModel.VehicleModelId);
                //Assert
                Assert.AreEqual(targetModel.VehicleModelId, result.VehicleModelId);
            }).GetAwaiter().GetResult();

        }

        [TestMethod]
        public void ModelRepositoryDeleteTest()
        {
            //Arrange
            //Init repo
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new ModelRepository(repository);
            var makeRepository = new MakeRepository(repository);

            //Create maker
            var vMake = new VehicleMakeDomain() { Name = "ModelRepositoryDeleteTest", Abrv = "ModelRepositoryDeleteTest" };
            Task.Run(async () =>
            {
                var response = await makeRepository.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Get maker
            IEnumerable<IVehicleMakeDomain> getAllMakers = null;
            IVehicleMakeDomain targetMaker = null;
            Task.Run(async () =>
            {
                getAllMakers = await makeRepository.GetAll();
                Assert.IsNotNull(getAllMakers);

                foreach (var item in getAllMakers)
                {
                    targetMaker = item;
                }
            }).GetAwaiter().GetResult();

            //Create model
            var vModel = new VehicleModelDomain() { Name = "ModelRepositoryDeleteTest", Abrv = "ModelRepositoryDeleteTest", VehicleMakeId = targetMaker.VehicleMakeId };

            //Add model
            Task.Run(async () =>
            {
                var response = await testRepository.Add(vModel);

                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Get model
            IEnumerable<IVehicleModelDomain> getAll;
            IVehicleModelDomain targetModel = null;

            Task.Run(async () =>
            {
                getAll = await testRepository.GetAll();
                Assert.IsNotNull(getAll);

                foreach (var item in getAll)
                {
                    targetModel = item;
                }

                var result = await testRepository.Delete(targetModel.VehicleModelId);
                //Assert
                Assert.AreEqual(1, result);
            }).GetAwaiter().GetResult();

        }        

        [TestMethod]
        public void ModelRepositoryGetMakersModelsTest()
        {
            //Arrange
            //Init repo
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var testRepository = new ModelRepository(repository);
            var makeRepository = new MakeRepository(repository);

            //Create maker
            var vMake = new VehicleMakeDomain() { Name = "ModelRepositoryGetMakersModelsTest", Abrv = "ModelRepositoryGetMakersModelsTest" };
            Task.Run(async () =>
            {
                var response = await makeRepository.Add(vMake);
                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Get maker
            IEnumerable<IVehicleMakeDomain> getAllMakers = null;
            IVehicleMakeDomain targetMaker = null;
            Task.Run(async () =>
            {
                getAllMakers = await makeRepository.GetAll();
                Assert.IsNotNull(getAllMakers);

                foreach (var item in getAllMakers)
                {
                    targetMaker = item;
                }
            }).GetAwaiter().GetResult();

            //Create model
            var vModel = new VehicleModelDomain() { Name = "ModelRepositoryGetMakersModelsTest", Abrv = "ModelRepositoryGetMakersModelsTest", VehicleMakeId = targetMaker.VehicleMakeId };

            //Add model
            Task.Run(async () =>
            {
                var response = await testRepository.Add(vModel);

                Assert.AreEqual(1, response);
            }).GetAwaiter().GetResult();

            //Get model
            IEnumerable<IVehicleModelDomain> getAll;
            IVehicleModelDomain targetModel = null;

            Task.Run(async () =>
            {
                getAll = await testRepository.GetAll();
                Assert.IsNotNull(getAll);

                foreach (var item in getAll)
                {
                    targetModel = item;
                }

                var result = await testRepository.GetMakersModels(targetModel.VehicleMakeId);
                //Assert
                Assert.IsNotNull(result);
            }).GetAwaiter().GetResult();
        }
      

    }
}
