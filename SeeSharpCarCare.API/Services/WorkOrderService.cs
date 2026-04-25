using System.Data.Common;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly IRepository<WorkOrder> _workOrderRepository;
    private readonly IWorkOrderRepo _workOrderRepo;

    public WorkOrderService(IRepository<WorkOrder> workOrderRepository, IWorkOrderRepo workOrderRepo)
    {
        _workOrderRepository = workOrderRepository;
        _workOrderRepo = workOrderRepo;
    }

    async public Task<List<WorkOrder>> GetAllWorkOrders()
    {
        try
        {
            return await _workOrderRepository.GetAllFromRepository();
        }
        catch(DbException e)
        {
            throw new Exception(e.Message);
        }
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

    // async public Task<WorkOrder> RemoveWorkOrderService(WorkOrder workOrder)
    // {
    //     try
    //     {
    //         return await _workOrderRepository.RemoveFromRepository(workOrder);
    //     }
    //     catch (DbException e)
    //     {
    //         throw new Exception(e.Message);
    //     }
    // }

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
            // await RemoveWorkOrderService(workOrder); 
            // await AddWorkOrderService(workOrder);
            await _workOrderRepo.UpdateWorkOrderRepo(workOrder);
        }
        catch
        {
            throw new KeyNotFoundException("Work Order Not Found.");
        }
    }

    async public Task<WorkOrder> FindWorkOrderByIdService(int id)
    {
        WorkOrder workOrder = await _workOrderRepo.FindWorkOrderByIdInRepo(id);
        if (workOrder != null) return workOrder;
        else
            throw new KeyNotFoundException("Work Order Not Found.");
    }
}