using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkOrderTechnicianController : ControllerBase
{
    private readonly IWorkOrderTechnicianService _workOrderTechnicianService;

    public WorkOrderTechnicianController(IWorkOrderTechnicianService workOrderTechnicianService) { _workOrderTechnicianService = workOrderTechnicianService; }

    [HttpPatch]
    public async Task<ActionResult> UpdateWorkOrderTechnicianController(WorkOrderTechnicianDTO workOrderTechnicianDTO)
    {
        try
        {
            await _workOrderTechnicianService.UpdateWorkOrderTechnicianDTOService(workOrderTechnicianDTO);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
}
