using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface ITechnicianService
{
    Task<string> AddTechnicianService(Technician technician);
    // Task<string> RemoveVehicleService(Vehicle vehicle);
    // Task<string> RemoveVehicleByIdService(int id);
    // Task<string> UpdateVehicleService(Vehicle vehicle);
    // Task<Vehicle> FindVehicleByVINService(string vin);
}