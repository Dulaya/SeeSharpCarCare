using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public class TechnicianService : ITechnicianService
{
    private readonly IRepository<Technician> _technicianRepository;

    public TechnicianService(IRepository<Technician> technicianRepository)
    {
        _technicianRepository = technicianRepository;
    }


    async public Task<string> AddTechnicianService(Technician technician)
    {
        try
        {
            technician.Name = technician.Name.ToUpper();
            return await _technicianRepository.AddToRepository(technician);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

/*
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
        Vehicle vehicle = await _vehicleRepository.FindByIdInRepository(vin);
        if (vehicle != null) return vehicle;
        else return new Vehicle();
    }
    */
}