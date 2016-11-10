using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.MVCApi.AutoMapperConfig;
using LVL3.DAL;
using LVL3.Repository;
using LVL3.Repository.Repositorys;
using LVL3.Service;
using System.Web.Http;
using System.Net.Http;
using LVL3.MVCApi.Controllers;
using System.Threading.Tasks;
using LVL3.MVCApi.ViewModels;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace LVL3.MVCApi.Tests.Controllers
{
    [TestClass]
    public class ModelControllerTest
    {
        [TestMethod]
        public void ModelControllerGetAllTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var modelService = new ModelService(modelRepository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var makeController = new MakeController(makeService);
            var testController = new ModelController(modelService, makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();
            makeController.Request = new HttpRequestMessage();
            makeController.Configuration = new HttpConfiguration();
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            //Add make
            var vMake = new VehicleMakeView() { Name = "ModelControllerGetAllTest", Abrv = "ModelControllerGetAllTest" };

            Task.Run(async () =>
            {
                var response = await makeController.Add(vMake);
                Assert.IsNotNull(response);
            }).GetAwaiter().GetResult();

            //Get make
            VehicleMakeView targetItem = null;

            Task.Run(async () =>
            {
                var response = await makeController.GetAll();
                Assert.IsNotNull(response);

                IEnumerable<VehicleMakeView> obj = JSS.Deserialize<IEnumerable<VehicleMakeView>>(response.Content.ReadAsStringAsync().Result);
                targetItem = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Add model
            var vModel = new VehicleModelView() { Name = "ModelControllerGetAllTest", Abrv = "ModelControllerGetAllTest", VehicleMakeId = targetItem.VehicleMakeId };

            Task.Run(async () =>
            {
                var result = await testController.Add(vModel);
                var obj = JSS.Deserialize<int>(result.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var result = await testController.GetAll();
                var obj = JSS.Deserialize<IEnumerable<VehicleModelView>>(result.Content.ReadAsStringAsync().Result);
                //Assert
                Assert.IsNotNull(obj);
            }).GetAwaiter().GetResult();
        }


        [TestMethod]
        public void ModelControllerGetTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var modelService = new ModelService(modelRepository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var makeController = new MakeController(makeService);
            var testController = new ModelController(modelService, makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();
            makeController.Request = new HttpRequestMessage();
            makeController.Configuration = new HttpConfiguration();
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            //Add make
            var vMake = new VehicleMakeView() { Name = "ModelControllerGetTest", Abrv = "ModelControllerGetTest" };

            Task.Run(async () =>
            {
                var response = await makeController.Add(vMake);
                var obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

            //Get make
            VehicleMakeView targetItem = null;

            Task.Run(async () =>
            {
                var response = await makeController.GetAll();
                Assert.IsNotNull(response);

                IEnumerable<VehicleMakeView> obj = JSS.Deserialize<IEnumerable<VehicleMakeView>>(response.Content.ReadAsStringAsync().Result);
                targetItem = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Add model
            var vModel = new VehicleModelView() { Name = "ModelControllerGetTest", Abrv = "ModelControllerGetTest", VehicleMakeId = targetItem.VehicleMakeId };

            Task.Run(async () =>
            {
                var response = await testController.Add(vModel);
                var obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

            VehicleModelView targetModel = null;
            //Get all models
            Task.Run(async () =>
            {
                var response = await testController.GetAll();
                var obj = JSS.Deserialize<IEnumerable<VehicleModelView>>(response.Content.ReadAsStringAsync().Result);
                Assert.IsNotNull(obj);
                targetModel = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            
            Task.Run(async () =>
            {
                //Act
                var result = await testController.Get(targetModel.VehicleModelId);
                var obj = JSS.Deserialize<VehicleModelView>(result.Content.ReadAsStringAsync().Result);
                //Assert
                Assert.AreEqual(targetModel.VehicleModelId, obj.VehicleModelId);
            }).GetAwaiter().GetResult();

        }



        [TestMethod]
        public void ModelControllerDeleteTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var modelService = new ModelService(modelRepository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var makeController = new MakeController(makeService);
            var testController = new ModelController(modelService, makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();
            makeController.Request = new HttpRequestMessage();
            makeController.Configuration = new HttpConfiguration();
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            //Add make
            var vMake = new VehicleMakeView() { Name = "ModelControllerDeleteTest", Abrv = "ModelControllerDeleteTest" };

            Task.Run(async () =>
            {
                var response = await makeController.Add(vMake);
                var obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

            //Get make
            VehicleMakeView targetItem = null;

            Task.Run(async () =>
            {
                var response = await makeController.GetAll();
                Assert.IsNotNull(response);

                IEnumerable<VehicleMakeView> obj = JSS.Deserialize<IEnumerable<VehicleMakeView>>(response.Content.ReadAsStringAsync().Result);
                targetItem = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Add model
            var vModel = new VehicleModelView() { Name = "ModelControllerDeleteTest", Abrv = "ModelControllerDeleteTest", VehicleMakeId = targetItem.VehicleMakeId };

            Task.Run(async () =>
            {
                var response = await testController.Add(vModel);
                var obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

            VehicleModelView targetModel = null;
            //Get all models
            Task.Run(async () =>
            {
                var response = await testController.GetAll();
                var obj = JSS.Deserialize<IEnumerable<VehicleModelView>>(response.Content.ReadAsStringAsync().Result);
                Assert.IsNotNull(obj);
                targetModel = obj.LastOrDefault();
            }).GetAwaiter().GetResult();


            Task.Run(async () =>
            {
                //Act
                var result = await testController.Delete(targetModel.VehicleModelId);
                var obj = JSS.Deserialize<int>(result.Content.ReadAsStringAsync().Result);
                //Assert
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

        }


        [TestMethod]
        public void ModelControllerUpdateTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var modelService = new ModelService(modelRepository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var makeController = new MakeController(makeService);
            var testController = new ModelController(modelService, makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();
            makeController.Request = new HttpRequestMessage();
            makeController.Configuration = new HttpConfiguration();
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            //Add make
            var vMake = new VehicleMakeView() { Name = "ModelControllerUpdateTest", Abrv = "ModelControllerUpdateTest" };

            Task.Run(async () =>
            {
                var response = await makeController.Add(vMake);
                var obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

            //Get make
            VehicleMakeView targetItem = null;

            Task.Run(async () =>
            {
                var response = await makeController.GetAll();
                Assert.IsNotNull(response);

                IEnumerable<VehicleMakeView> obj = JSS.Deserialize<IEnumerable<VehicleMakeView>>(response.Content.ReadAsStringAsync().Result);
                targetItem = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            //Add model
            var vModel = new VehicleModelView() { Name = "ModelControllerUpdateTest", Abrv = "ModelControllerUpdateTest", VehicleMakeId = targetItem.VehicleMakeId };

            Task.Run(async () =>
            {
                var response = await testController.Add(vModel);
                var obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

            VehicleModelView targetModel = null;
            //Get all models
            Task.Run(async () =>
            {
                var response = await testController.GetAll();
                var obj = JSS.Deserialize<IEnumerable<VehicleModelView>>(response.Content.ReadAsStringAsync().Result);
                Assert.IsNotNull(obj);
                targetModel = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            targetModel.Name = "ModelControllerUpdateTestTested";

            Task.Run(async () =>
            {
                //Act
                var result = await testController.Update(targetModel);
                var obj = JSS.Deserialize<int>(result.Content.ReadAsStringAsync().Result);
                //Assert
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();

        }


    }
}
