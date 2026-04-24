using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkOrderController : ControllerBase
{
    private readonly IWorkOrderService _workOrderService;

    public WorkOrderController(IWorkOrderService workOrderService) { _workOrderService = workOrderService; }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkOrder>> GetWorkOrderByIdController(int id)
    {
        try
        {
            WorkOrder workOrder = await _workOrderService.FindWorkOrderByIdService(id);
            return workOrder;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    async public Task<ActionResult<WorkOrder>> PostWorkOrderController(WorkOrder workOrder)
    {
        try
        {
            return await _workOrderService.AddWorkOrderService(workOrder);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // [HttpDelete("{id}")]
    // public async Task<ActionResult> DeleteWorkOrderController(int id)
    // {
    //     try
    //     {
    //         await _workOrderService.RemoveWorkOrderByIdService(id);
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    //     return NoContent();
    // }

    [HttpPatch]
    public async Task<ActionResult> UpdateWorkOrderController(WorkOrder workOrder)
    {
        try
        {
           await _workOrderService.UpdateWorkOrderService(workOrder);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
}
