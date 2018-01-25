using LearningTesting.DataModel;
using LearningTesting.IServices;
using LearningTesting.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity;

namespace LearningTesting.Test
{
    [TestClass]
    public class VehicleServiceTests
    {
        private IUnityContainer container;
        private IVehicleService vehicleService;


        [TestInitialize]
        public async Task Setup()
        {
            container = new UnityContainer();

            await Helpers.LearningTestingHelper.RegisterLearningTestingHelper(container);

            container.RegisterType<IVehicleService, VehicleService>();

            vehicleService = container.Resolve<IVehicleService>();
        }

        /// <summary>
        /// Testing method which creates objects in repository and delete all this objects with the service.
        /// </summary>
        [TestMethod]
        public async Task VehicleService_DeleteAllTest()
        {
            IDatabaseRepo dbRepo = container.Resolve<IDatabaseRepo>();
            List<Vehicle> vehiclesList = new List<Vehicle>()
            {
                new Vehicle()
                {
                  Brand = "BMW",
                  Model = "320D",
                  Colour = "Black"
                },
                new Vehicle()
                {
                  Brand = "BMW",
                  Model = "320D",
                  Colour = "White"
                },
                new Vehicle()
                {
                  Brand = "AUDI",
                  Model = "A5",
                  Colour = "Black"
                }
            };

            var result1 = await dbRepo.Create<Vehicle>(vehiclesList[0]);
            var result2 = await dbRepo.Create<Vehicle>(vehiclesList[1]);
            var result3 = await dbRepo.Create<Vehicle>(vehiclesList[2]);
            var result = await vehicleService.DeleteAll();

            Assert.AreEqual(result, vehiclesList.Count);
        }

        /// <summary>
        /// Testing method which creates objects with the service.
        /// </summary>
        [TestMethod]
        public async Task VehicleService_AddVehicleTest()
        {
            var vehicle = new Vehicle()
            {
                Brand = "BMW",
                Model = "320D",
                Colour = "Black"
            };

            var result = await vehicleService.AddVehicle(vehicle);

            Assert.AreNotEqual(vehicle.Id, result.Id);

            await vehicleService.DeleteVehicle(result.Id);
        }

        /// <summary>
        /// Testing method which creates an object with the repository and deletes it with the service.
        /// </summary>
        [TestMethod]
        public async Task VehicleService_DeleteVehicleTest()
        {
            IDatabaseRepo dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                Brand = "BMW",
                Model = "320D",
                Colour = "Black"
            };

            var result = await dbRepo.Create<Vehicle>(vehicle);
            var resultDelete = await vehicleService.DeleteVehicle(result.Id);

            Assert.IsTrue(resultDelete);
        }

        /// <summary>
        /// Testing method which creates an object with the repository and gets it with the service.
        /// </summary>
        [TestMethod]
        public async Task VehicleService_GetVehicleTest()
        {
            IDatabaseRepo dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                Brand = "BMW",
                Model = "320D",
                Colour = "Black"
            };

            var result = await dbRepo.Create<Vehicle>(vehicle);
            var resultGet = await vehicleService.GetVehicle(result.Id);

            Assert.AreEqual(resultGet.Id, result.Id);
            await vehicleService.DeleteVehicle(result.Id);
        }

        /// <summary>
        /// Testing method which creates an object with the repository and updates it with the service.
        /// </summary>
        [TestMethod]
        public async Task VehicleService_UpdateVehicleTest()
        {
            IDatabaseRepo dbRepo = container.Resolve<IDatabaseRepo>();
            var vehicle = new Vehicle()
            {
                Brand = "BMW",
                Model = "320D",
                Colour = "Black"
            };

            //Save object o DB
            var result = await dbRepo.Create<Vehicle>(vehicle);

            //Edit Model object
            result.Model = "535I";

            //Update the object on DB
            var resultUpdate = await vehicleService.UpdateVehicle(result.Id,result);

            Assert.AreEqual(resultUpdate.Model, result.Model);
            await vehicleService.DeleteVehicle(resultUpdate.Id);
        }

        /// <summary>
        /// Testing method which creates a list of objects with the repository and get it with the service.
        /// </summary>
        [TestMethod]
        public async Task VehicleService_GetVehiclesTest()
        {
            IDatabaseRepo dbRepo = container.Resolve<IDatabaseRepo>();
            List<Vehicle> vehiclesList = new List<Vehicle>()
            {
                new Vehicle()
                {
                  Brand = "BMW",
                  Model = "320D",
                  Colour = "Black"
                },
                new Vehicle()
                {
                  Brand = "BMW",
                  Model = "320D",
                  Colour = "White"
                },
                new Vehicle()
                {
                  Brand = "AUDI",
                  Model = "A5",
                  Colour = "Black"
                }
            };

            var result1 = await dbRepo.Create<Vehicle>(vehiclesList[0]);
            var result2 = await dbRepo.Create<Vehicle>(vehiclesList[1]);
            var result3 = await dbRepo.Create<Vehicle>(vehiclesList[2]);
            var resultGet = await vehicleService.GetVehicles();

            Assert.AreEqual(resultGet.ToList().Count, 3);
        }

       

    }
}
