using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService) { _vehicleService = vehicleService; }

    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> GetAllVehiclesController()
    {
        try
        {
            List<Vehicle> vehicles = await _vehicleService.GetAllVehiclesService();
            return vehicles;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{vin}")]
    public async Task<ActionResult<Vehicle>> GetVehicleByVINController(string vin)
    {
        try
        {
            Vehicle vehicle = await _vehicleService.FindVehicleByIdService(vin);
            return vehicle;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    async public Task<ActionResult<Vehicle>> PostVehicleController(Vehicle newVehicle)
    {
        try
        {
            return await _vehicleService.AddVehicleService(newVehicle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{vin}")]
    public async Task<ActionResult> DeleteVehicleController(string vin)
    {
        try
        {
            await _vehicleService.RemoveVehicleByIdService(vin);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateVehicleController(Vehicle vehicle)
    {
        try
        {
            await _vehicleService.UpdateVehicleService(vehicle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
}
