using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IRepairService
{
Task<Repair> AddRepairService(Repair workOrder);
   Task<Repair> RemoveRepairService(Repair workOrder);
   Task RemoveRepairByIdService(int id);
    Task UpdateRepairService(Repair workOrder);
   Task<Repair> FindRepairByIdService(int id);
   Task<List<Repair>> GetAllRepairsService();
}