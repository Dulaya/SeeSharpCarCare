using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface ICustomerService
{
    Task<Customer> AddCustomerService(Customer customer);
    Task<Customer> RemoveCustomerService(Customer customer);
    Task RemoveCustomerByIdService(int id);
    Task UpdateCustomerService(Customer customer);
    Task<Customer> FindCustomerByIdService(int id);
    Task<List<Customer>> GetAllCustomersService();
}