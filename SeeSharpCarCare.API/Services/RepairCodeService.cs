using System.Data.Common;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IRepairCodeService
{
    public Task<List<RepairCode>> GetAllRepairCodesService();
}

public class RepairCodeService : IRepairCodeService
{
    private readonly IRepository<RepairCode> _repairCodeRepository;

    public RepairCodeService(IRepository<RepairCode> repairCodeRepository )
    {
        _repairCodeRepository = repairCodeRepository;
    }

    async public Task<List<RepairCode>> GetAllRepairCodesService()
    {
        try
        {
            return await _repairCodeRepository.GetAllFromRepository();
        }
        catch(DbException e)
        {
            throw new Exception(e.Message);
        }
    }
}