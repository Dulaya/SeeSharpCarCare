using System.Data.Common;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;

    public CustomerService(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    async public Task<Customer> AddCustomerService(Customer customer)
    {
        try
        {
            return await _customerRepository.AddToRepository(customer);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task<Customer> RemoveCustomerService(Customer customer)
    {
        try
        {
            return await _customerRepository.RemoveFromRepository(customer);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task RemoveCustomerByIdService(int id)
    {
        try
        {
            await _customerRepository.RemoveByIdFromRepository(id);
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task UpdateCustomerService(Customer customer)
    {
        try
        {
            await RemoveCustomerService(customer);
            await AddCustomerService(customer);
        }
        catch
        {
            throw new KeyNotFoundException("Customer Not Found.");
        }
    }

    async public Task<Customer> FindCustomerByIdService(int id)
    {
        Customer customer = await _customerRepository.FindByIdInRepository(id);
        if (customer != null) return customer;
        else
            throw new KeyNotFoundException("Customer Not Found.");
    }

    async public Task<List<Customer>> GetAllCustomersService()
    {
        List<Customer> cusomters = await _customerRepository.GetAllFromRepository();
        if (cusomters != null) return cusomters;
        else
            throw new KeyNotFoundException("Customer Not Found.");
    }
}