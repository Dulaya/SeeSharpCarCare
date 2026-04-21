using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IService<T>
{
    Task<string> AddService(T obj);
    // Task<string> RemoveService(T vehicle);
    // Task<string> RemoveByIdService(int id);
    // Task<string> UpdateService(T vehicle);
    // Task<Vehicle> FindVehicleByIdService(int id);
}