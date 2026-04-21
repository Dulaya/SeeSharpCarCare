using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/technicians")]
[ApiController]
public class Controller<T> : ControllerBase, IController<T> where T : class
{
    private readonly IService<Technician> _service;

    public Controller(IService<Technician> service) { _service = service; }

    [HttpGet]
    public string TestGET() => "Test GET";
    //[HttpGet("{id}")]
    [HttpPost]
    public async Task<ActionResult<string>> AddController(T obj)
    {
        try
        {
            Technician obj2 = new Technician
            {
              Name = "Joh SMith"  
            };
            Console.WriteLine("Start");
            var r = await _service.AddService(obj2); 
            Console.WriteLine("End");
            return "Added";
        }
        catch (Exception e)
        {
            return "BadRequest(e.Message)";
        }
    }


}
