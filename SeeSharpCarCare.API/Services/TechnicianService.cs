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

    async public Task<List<Technician>> GetAllTechniciansService()
    {
        List<Technician> technicians = await _technicianRepository.GetAllFromRepository();
        if (technicians != null) return technicians;
        else
            throw new KeyNotFoundException("Technicians Not Found.");
    }

    async public Task<Technician> AddTechnicianService(Technician technician)
    {
        try
        {
            string? name = technician.Name;
            // Capitalize each word
            technician.Name = string.Join(" ", name.Split(' ')
                      .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
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

    async public Task RemoveTechnicianByIdService(string id)
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
           await _technicianRepository.RemoveByIdFromRepository(technician.Id);
        }
        catch
        {
            throw new KeyNotFoundException("Technician Not Found.");
        }
        try
        {
            await _technicianRepository.AddToRepository(technician);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task<Technician> FindTechnicianByIdService(string id)
    {
        Technician technician = await _technicianRepository.FindByIdInRepository(id);
        if (technician != null) return technician;
        else
            throw new KeyNotFoundException("Technician Not Found.");
    }
}