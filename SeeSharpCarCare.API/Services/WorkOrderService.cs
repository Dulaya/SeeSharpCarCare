using System.Data.Common;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly IRepository<WorkOrder> _workOrderRepository;

    public WorkOrderService(IRepository<WorkOrder> workOrderRepository)
    {
        _workOrderRepository = workOrderRepository;
    }

    async public Task<WorkOrder> AddWorkOrderService(WorkOrder workOrder)
    {
        try
        {
            return await _workOrderRepository.AddToRepository(workOrder);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task<WorkOrder> RemoveWorkOrderService(WorkOrder workOrder)
    {
        try
        {
            return await _workOrderRepository.RemoveFromRepository(workOrder);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task RemoveWorkOrderByIdService(int id)
    {
        try
        {
             await _workOrderRepository.RemoveByIdFromRepository(id);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task UpdateWorkOrderService(WorkOrder workOrder)
    {
        try
        {
            await RemoveWorkOrderService(workOrder); 
            await AddWorkOrderService(workOrder);
        }
        catch
        {
            throw new KeyNotFoundException("Work Order Not Found.");
        }
    }

    async public Task<WorkOrder> FindWorkOrderByIdService(int id)
    {
        WorkOrder workOrder = await _workOrderRepository.FindByIdInRepository(id);
        if (workOrder != null) return workOrder;
        else
            throw new KeyNotFoundException("Work Order Not Found.");
    }
}