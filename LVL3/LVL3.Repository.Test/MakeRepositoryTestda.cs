using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LVL3.Repository.Common;
using LVL3.Model.DomainModels;

namespace LVL3.Repository.Test
{
    /// <summary>
    /// Summary description for MakeRepositoryTest
    /// </summary>
    [TestClass]
    public class MakeRepositoryTestda
    {
        protected VehicleMakeDomain TestObject { get; private set; }
        private readonly IMakeRepository MakeRepositroy;

        public MakeRepositoryTestda(IMakeRepository makeRepository)
        {
            MakeRepositroy = makeRepository;
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public async void TestAdd()
        {
            //Arrange
            TestObject = new VehicleMakeDomain { Name = "test1", Abrv = "testAbrv", VehicleMakeId = Guid.NewGuid() };
            //Act
            var result = await MakeRepositroy.Add(TestObject);
            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async void TestGet()
        {
            //Act
            var result = await MakeRepositroy.Get(TestObject.VehicleMakeId);
            //Assert
            Assert.AreEqual(TestObject, result);
        }

        [TestMethod]
        public async void TestUpdate()
        {
            var testObject = await MakeRepositroy.Get(TestObject.VehicleMakeId);
            testObject.Name = "NameChanged";
            //Act
            await MakeRepositroy.Update(testObject);
            var result = await MakeRepositroy.Get(TestObject.VehicleMakeId);
            //Assert
            Assert.AreEqual(testObject, result);
        }

        [TestMethod]
        public async void TestDelete()
        {
            var result = await MakeRepositroy.Delete(TestObject.VehicleMakeId);
            Assert.AreEqual(0, result);
        }


    }
}
