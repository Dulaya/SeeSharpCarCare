using SeeSharpCarCare.Core.Data;
using SeeSharpCarCare.Core.Models;

namespace SeeSharpCarCare.Core.Services;

public class VehicleService
{
    VehicleRepository vehicleRepository = new();

    async public Task<string> AddVehicle(Vehicle vehicle)
    {
        try
        {
            vehicle.VIN = vehicle.VIN.ToUpper();
            return await vehicleRepository.AddVehicle(vehicle);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    async public Task<string> RemoveVehicle(Vehicle vehicle)
    => await vehicleRepository.RemoveVehicle(vehicle);

}