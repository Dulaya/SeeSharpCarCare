using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/technicians")]
[ApiController]
public class TechnicianController : ControllerBase
{
    private readonly ITechnicianService _technicianService;

    public TechnicianController(ITechnicianService technicianService) { _technicianService = technicianService; }

    [HttpGet("{id}")]
    public async Task<ActionResult<string>> GetVehicleByVINController(string id)
    {
        try
        {
            Console.WriteLine("tech");
            Technician obj3 = new Technician
            {
                Name = "Joh SMith"
            };
            string technician = await _technicianService.AddTechnicianService(obj3);
            return "technician";
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
