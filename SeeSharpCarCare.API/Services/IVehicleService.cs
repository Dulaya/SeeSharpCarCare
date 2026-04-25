using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IVehicleService
{
    Task<Vehicle> AddVehicleService(Vehicle vehicle);
    Task<Vehicle> RemoveVehicleService(Vehicle vehicle);
    Task RemoveVehicleByIdService(string vin);
    Task UpdateVehicleService(Vehicle vehicle);
    Task<Vehicle> FindVehicleByIdService(string vin);
    Task<List<Vehicle>> GetAllVehiclesService();

}