using LearningTesting.DataModel;
using LearningTesting.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTesting.Services
{
    public class VehicleService : IVehicleService
    {
        private IDatabaseRepo dbRepo;

        public VehicleService(IDatabaseRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        async Task<Vehicle> IVehicleService.AddVehicle(Vehicle v)
        {
            return await dbRepo.Create<Vehicle>(v);
        }

        async Task<bool> IVehicleService.DeleteVehicle(Guid id)
        {
            return await dbRepo.Delete<Vehicle>(id);
        }

        async Task<Vehicle> IVehicleService.GetVehicle(Guid id)
        {
            return await dbRepo.Get<Vehicle>(id);
        }

        async Task<IEnumerable<Vehicle>> IVehicleService.GetVehicles()
        {
            return await dbRepo.Get<Vehicle>();
        }

        async Task<Vehicle> IVehicleService.UpdateVehicle(Guid Id, Vehicle v)
        {
            return await dbRepo.Update<Vehicle>(Id, v);
        }
       
        async Task<int> IVehicleService.DeleteAll()
        {
            return await dbRepo.DeleteAll<Vehicle>();
        }
    }
}
