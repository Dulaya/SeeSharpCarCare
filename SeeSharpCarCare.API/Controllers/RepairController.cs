using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepairController : ControllerBase
{
    private readonly IRepairService _repairService;

    public RepairController(IRepairService repairService) { _repairService = repairService; }

    [HttpGet]
    public async Task<ActionResult<List<Repair>>> GetAllRepairsController()
    {
        try
        {
            List<Repair> repairs = await _repairService.GetAllRepairsService();
            return repairs;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repair>> GetRepairByVINController(int id)
    {
        try
        {
            Repair repair = await _repairService.FindRepairByIdService(id);
            return repair;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    async public Task<ActionResult<Repair>> PostRepairController(Repair repair)
    {
        try
        {
            return await _repairService.AddRepairService(repair);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRepairController(int id)
    {
        try
        {
            await _repairService.RemoveRepairByIdService(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateRepairController(Repair repair)
    {
        try
        {
            await _repairService.UpdateRepairService(repair);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
}
