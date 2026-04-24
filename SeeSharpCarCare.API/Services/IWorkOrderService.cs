using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IWorkOrderService
{
Task<WorkOrder> AddWorkOrderService(WorkOrder workOrder);
   // Task<WorkOrder> RemoveWorkOrderService(WorkOrder workOrder);
  //  Task RemoveWorkOrderByIdService(int id);
    Task UpdateWorkOrderService(WorkOrder workOrder);
   Task<WorkOrder> FindWorkOrderByIdService(int id);
}