using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly VehicleService _vehicleService;

    public Controller(VehicleService vehicleService) => _vehicleService = vehicleService;

    // [HttpGet]
    // async public Task<string> HI()
    // {
    //     try
    //     {
    //         return "HELLO";
    //     }
    //     catch
    //     {
    //         return "Error";
    //     }
    // }
    [HttpGet]
    public async Task<ActionResult<Vehicle>> GetVehicleByVINController(string id)
    {
        try
        {
            Vehicle vehicle = await _vehicleService.FindVehicleByVINService(id); 
            return vehicle;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    // [HttpGet("{id}")]
    // async public Task<string> HI2(int id)
    // {
    //     try
    //     {
    //         return $"HELLO{id}";
    //     }
    //     catch
    //     {
    //         return $"Error{id}";
    //     }
    // }


}
