using System.Data.Common;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public class VehicleService : IVehicleService
{
    private readonly IRepository<Vehicle> _vehicleRepository;

    public VehicleService(IRepository<Vehicle> vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    async public Task<Vehicle> AddVehicleService(Vehicle vehicle)
    {
        try
        {
            vehicle.VIN = vehicle.VIN.ToUpper();
            return await _vehicleRepository.AddToRepository(vehicle);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task<Vehicle> RemoveVehicleService(Vehicle vehicle)
    {
        try
        {
            return await _vehicleRepository.RemoveFromRepository(vehicle);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task RemoveVehicleByIdService(string vin)
    {
        try
        {
             await _vehicleRepository.RemoveByIdFromRepository(vin);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }
    
    async public Task UpdateVehicleService(Vehicle vehicle)
    {
        try
        {
            await RemoveVehicleService(vehicle);
            await AddVehicleService(vehicle);
        }
        catch
        {
            throw new KeyNotFoundException("Vehicle Not Found.");
        }
    }

    async public Task<Vehicle> FindVehicleByIdService(string vin)
    {
        Vehicle vehicle = await _vehicleRepository.FindByIdInRepository(vin);
        if (vehicle != null) return vehicle;
        else
            throw new KeyNotFoundException("Vehicle Not Found.");
    }
}