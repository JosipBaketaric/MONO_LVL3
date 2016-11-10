using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.MVCApi.AutoMapperConfig;
using LVL3.DAL;
using LVL3.Repository;
using LVL3.Model.DomainModels;
using LVL3.Service;
using LVL3.Repository.Repositorys;
using LVL3.MVCApi.Controllers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using LVL3.MVCApi.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Linq;

namespace LVL3.MVCApi.Tests.Controllers
{
    [TestClass]
    public class MakeControllerTest
    {
        [TestMethod]
        public void MakeControllerGetAllTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testController = new MakeController(makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();

            //Add make
            var vMake = new VehicleMakeView() { Name = "MakeControllerGetAllTest", Abrv = "MakeControllerGetAllTest" };

            Task.Run(async () =>
            {
                var response = await testController.Add(vMake);
                Assert.IsNotNull(response);
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var result = await testController.GetAll();
                //Assert
                Assert.IsNotNull(result);
            }).GetAwaiter().GetResult();

        }


        [TestMethod]
        public void MakeControllerGetTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testController = new MakeController(makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();

            //Add make
            var vMake = new VehicleMakeView() { Name = "MakeControllerGetTest", Abrv = "MakeControllerGetTest" };

            Task.Run(async () =>
            {
                var response = await testController.Add(vMake);
                Assert.IsNotNull(response);
            }).GetAwaiter().GetResult();

            //Get make
            VehicleMakeView targetItem = null;
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            Task.Run(async () =>
            {
                var response = await testController.GetAll();
                Assert.IsNotNull(response);
                
                IEnumerable<VehicleMakeView> obj = JSS.Deserialize<IEnumerable<VehicleMakeView>>(response.Content.ReadAsStringAsync().Result);
                targetItem = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var response = await testController.Get(targetItem.VehicleMakeId);
                //Assert
                VehicleMakeView obj = JSS.Deserialize<VehicleMakeView>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(targetItem.VehicleMakeId, obj.VehicleMakeId);
            }).GetAwaiter().GetResult();

        }

        [TestMethod]
        public void MakeControllerAddTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testController = new MakeController(makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();

            //Add make
            var vMake = new VehicleMakeView() { Name = "MakeControllerAddTest", Abrv = "MakeControllerAddTest" };

            Task.Run(async () =>
            {
                //Act
                var result = await testController.Add(vMake);
                //Assert
                Assert.IsNotNull(result);
            }).GetAwaiter().GetResult();

        }


        [TestMethod]
        public void MakeControllerDeleteTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testController = new MakeController(makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();

            //Add make
            var vMake = new VehicleMakeView() { Name = "MakeControllerDeleteTest", Abrv = "MakeControllerDeleteTest" };

            Task.Run(async () =>
            {
                var response = await testController.Add(vMake);
                Assert.IsNotNull(response);
            }).GetAwaiter().GetResult();

            //Get make
            VehicleMakeView targetItem = null;
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            Task.Run(async () =>
            {
                var response = await testController.GetAll();
                Assert.IsNotNull(response);

                IEnumerable<VehicleMakeView> obj = JSS.Deserialize<IEnumerable<VehicleMakeView>>(response.Content.ReadAsStringAsync().Result);
                targetItem = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                //Act
                var response = await testController.Delete(targetItem.VehicleMakeId);
                //Assert
               int obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();
        }


        [TestMethod]
        public void MakeControllerUpdateTest()
        {
            //Arange
            IncludeAllMappings.include();
            var context = new VehicleContext();
            var repository = new Repository.Repositorys.Repository(context, new UnitOfWorkFactory(new UnitOfWork(context)));
            var makeRepository = new MakeRepository(repository);
            var modelRepository = new ModelRepository(repository);
            var makeService = new MakeService(makeRepository, modelRepository);
            var testController = new MakeController(makeService);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();

            //Add make
            var vMake = new VehicleMakeView() { Name = "MakeControllerUpdateTest", Abrv = "MakeControllerUpdateTest" };

            Task.Run(async () =>
            {
                var response = await testController.Add(vMake);
                Assert.IsNotNull(response);
            }).GetAwaiter().GetResult();

            //Get make
            VehicleMakeView targetItem = null;
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            Task.Run(async () =>
            {
                var response = await testController.GetAll();
                Assert.IsNotNull(response);

                IEnumerable<VehicleMakeView> obj = JSS.Deserialize<IEnumerable<VehicleMakeView>>(response.Content.ReadAsStringAsync().Result);
                targetItem = obj.LastOrDefault();
            }).GetAwaiter().GetResult();

            targetItem.Name = "MakeControllerUpdateTestTested";

            Task.Run(async () =>
            {
                //Act
                var response = await testController.Update(targetItem);
                //Assert
                int obj = JSS.Deserialize<int>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(1, obj);
            }).GetAwaiter().GetResult();
        }


    }
}
