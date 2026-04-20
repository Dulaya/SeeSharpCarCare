using SeeSharpCarCare.Core.Data;
using SeeSharpCarCare.Core.Models;

namespace SeeSharpCarCare.Core.Services;

public class VehicleService
{
    private Repository<Vehicle> _vehicleRepository = new();

    async public Task<string> AddVehicleService(Vehicle vehicle)
    {
        try
        {
            vehicle.VIN = vehicle.VIN.ToUpper();
            return await _vehicleRepository.AddToRepository(vehicle);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    async public Task<string> RemoveVehicleService(Vehicle vehicle)
        => await _vehicleRepository.RemoveFromRepository(vehicle);

    async public Task<string> RemoveVehicleByIdService(int id)
        => await _vehicleRepository.RemoveByIdFromRepository(id);
    async public Task<string> UpdateVehicleService(Vehicle vehicle)
    {
        try
        {
            await RemoveVehicleService(vehicle);
            await AddVehicleService(vehicle);
            return "Vehicle Updated.";
        }
        catch
        {
            return "Vehicle Not Found.";
        }
    }

    async public Task<Vehicle> FindVehicleByVINService(string vin)
    {
        Vehicle? vehicle = await _vehicleRepository.FindByIdInRepository(vin);
        if (vehicle != null) return vehicle;
        else return null;
    }
}