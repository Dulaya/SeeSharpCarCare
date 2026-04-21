using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/vehicles")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService) { _vehicleService = vehicleService; }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicleByVINController(string id)
    {
        try
        {
            Console.WriteLine("Veh");
            Vehicle vehicle = await _vehicleService.FindVehicleByVINService(id); 
            return vehicle;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
