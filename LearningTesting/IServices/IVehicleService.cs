using LearningTesting.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningTesting.IServices
{
    public interface IVehicleService
    {
        /// <summary>
        /// Function which retrieves the object by id.
        /// </summary>
        /// <param name="id">Object ID.</param>
        /// <returns>The required object.</returns>
        Task<Vehicle> GetVehicle(Guid id);

        /// <summary>
        /// Function which retrieves all the objects from a file.
        /// </summary>
        /// <returns>All the objects from a file.</returns>
        Task<IEnumerable<Vehicle>> GetVehicles();

        /// <summary>
        /// Adds an object to a file.
        /// </summary>
        /// <param name="v">The object we want to save.</param>
        /// <returns>The object saved.</returns> 
        Task<Vehicle> AddVehicle(Vehicle v);

        /// <summary>
        /// Deletes an object from table by ID
        /// </summary>
        /// <param name="id">The ID of the object we want to remove.</param>
        /// <returns>True if the object was removed, false if not.</returns>
        Task<bool> DeleteVehicle(Guid id);

        /// <summary>
        /// Updates an object from file.
        /// </summary>
        /// <param name="Id">The ID of the object we want to update.</param>
        /// <param name="v">The new value.</param>
        /// <returns>The object with the updated information.</returns>
        Task<Vehicle> UpdateVehicle(Guid Id, Vehicle v);

        /// <summary>
        /// Deletes all the objects from a file.
        /// </summary>
        /// <returns>The number of objects were removed.</returns>
        Task<int> DeleteAll();
    }
}
