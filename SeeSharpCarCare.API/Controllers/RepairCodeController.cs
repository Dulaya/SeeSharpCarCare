using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepairCodeController : ControllerBase
{
    private readonly IRepairCodeService _repairCodeService;

    public RepairCodeController(IRepairCodeService repairCodeService) { _repairCodeService = repairCodeService; }

    [HttpGet]
    public async Task<ActionResult<List<RepairCode>>> GetAllRepairCodesController()
    {
        try
        {
            List<RepairCode> repairCodes = await _repairCodeService.GetAllRepairCodesService();
            return repairCodes;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
