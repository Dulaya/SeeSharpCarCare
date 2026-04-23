using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechWorkOrderController : ControllerBase
{
    private readonly ITechWorkOrderService _techWorkOrderService;

    public TechWorkOrderController(ITechWorkOrderService techWorkOrderService) { _techWorkOrderService = techWorkOrderService; }

    [HttpPatch]
    public async Task<ActionResult> UpdateTechWorkOrderController(TechWorkOrderDTO techWorkOrderDTO)
    {
        try
        {
            await _techWorkOrderService.UpdateTechWorkOrderDTOService(techWorkOrderDTO);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
}
