using System.Data.Common;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public class RepairService : IRepairService
{
    private readonly IRepository<Repair> _repairRepository;

    public RepairService(IRepository<Repair> repairRepository)
    {
        _repairRepository = repairRepository;
    }

    async public Task<Repair> AddRepairService(Repair repair)
    {
        try
        {
            return await _repairRepository.AddToRepository(repair);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task<Repair> RemoveRepairService(Repair repair)
    {
        try
        {
            return await _repairRepository.RemoveFromRepository(repair);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task RemoveRepairByIdService(int id)
    {
        try
        {
            await _repairRepository.RemoveByIdFromRepository(id);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task UpdateRepairService(Repair repair)
    {
        try
        {
            await RemoveRepairService(repair);
            await AddRepairService(repair);
        }
        catch
        {
            throw new KeyNotFoundException("Repair Not Found.");
        }
    }

    async public Task<Repair> FindRepairByIdService(int id)
    {
        Repair repair = await _repairRepository.FindByIdInRepository(id);
        if (repair != null) return repair;
        else
            throw new KeyNotFoundException("Repair Not Found.");
    }

    async public Task<List<Repair>> GetAllRepairsService()
    {
        List<Repair> repairs = await _repairRepository.GetAllFromRepository();
        if (repairs is not null) return repairs;
        else
            throw new KeyNotFoundException("Repair Not Found.");
    }
}