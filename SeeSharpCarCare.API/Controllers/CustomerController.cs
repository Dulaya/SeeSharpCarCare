using Microsoft.AspNetCore.Mvc;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService) { _customerService = customerService; }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAllCustomersController()
    {
        try
        {
            List<Customer> customers = await _customerService.GetAllCustomersService();
            return customers;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerByIdController(int id)
    {
        try
        {
            Customer customer = await _customerService.FindCustomerByIdService(id);
            return customer;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    async public Task<ActionResult<Customer>> PostCustomerController(Customer newCustomer)
    {
        try
        {
            return await _customerService.AddCustomerService(newCustomer);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomerController(int id)
    {
        try
        {
            await _customerService.RemoveCustomerByIdService(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateCustomerController(Customer customer)
    {
        try
        {
            await _customerService.UpdateCustomerService(customer);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
}
