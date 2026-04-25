using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechnicianController : ControllerBase
{
    private readonly ITechnicianService _technicianService;

    public TechnicianController(ITechnicianService technicianService) { _technicianService = technicianService; }

    [HttpGet]
    public async Task<ActionResult<List<Technician>>> GetAllTechniciansController()
    {
        try
        {
            List<Technician> technicians = await _technicianService.GetAllTechniciansService();
            return technicians;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Technician>> GetTechnicianByIdController(string id)
    {
        try
        {
            Technician technician = await _technicianService.FindTechnicianByIdService(id);
            return technician;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    async public Task<ActionResult<Technician>> PostTechnicianController(Technician technician)
    {
        try
        {
            return await _technicianService.AddTechnicianService(technician);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTechnicianController(string id)
    {
        try
        {
            await _technicianService.RemoveTechnicianByIdService(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateTechnicianController(Technician technician)
    {
        try
        {
            await _technicianService.UpdateTechnicianService(technician);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
}
