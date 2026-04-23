using System.Data.Common;
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

    async public Task<Technician> AddTechnicianService(Technician technician)
    {
        try
        {
            return await _technicianRepository.AddToRepository(technician);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task<Technician> RemoveTechnicianService(Technician technician)
    {
        try
        {
            return await _technicianRepository.RemoveFromRepository(technician);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task RemoveTechnicianByIdService(int id)
    {
        try
        {
             await _technicianRepository.RemoveByIdFromRepository(id);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task UpdateTechnicianService(Technician technician)
    {
        try
        {
            await RemoveTechnicianService(technician); 
            await AddTechnicianService(technician);
        }
        catch
        {
            throw new KeyNotFoundException("Technician Not Found.");
        }
    }

    async public Task<Technician> FindTechnicianByIdService(int id)
    {
        Technician technician = await _technicianRepository.FindByIdInRepository(id);
        if (technician != null) return technician;
        else
            throw new KeyNotFoundException("Technician Not Found.");
    }
}