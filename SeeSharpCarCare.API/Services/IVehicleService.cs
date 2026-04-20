using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IVehicleService
{
    Task<string> AddVehicleService(Vehicle vehicle);
    Task<string> RemoveVehicleService(Vehicle vehicle);
    Task<string> RemoveVehicleByIdService(int id);
    Task<string> UpdateVehicleService(Vehicle vehicle);
    Task<Vehicle> FindVehicleByVINService(string vin);
}