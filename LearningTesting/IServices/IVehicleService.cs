using LearningTesting.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningTesting.IServices
{
    public interface IVehicleService
    {
        Task<Vehicle> GetVehicle(Guid id);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> AddVehicle(Vehicle v);
        Task<bool> DeleteVehicle(Guid id);
        Task<Vehicle> UpdateVehicle(Guid Id, Vehicle v);
        Task<int> DeleteAll();
    }
}
