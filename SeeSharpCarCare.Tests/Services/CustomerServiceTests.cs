using Moq;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;
using Xunit.Abstractions;

namespace SeeSharpCarCare.Tests.Services;

public class CustomerServiceTests
{
    private readonly ITestOutputHelper _output;

    private readonly Mock<IRepository<Customer>> _repoMock;

    private readonly CustomerService _systemUnderTest;

    public CustomerServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _repoMock = new Mock<IRepository<Customer>>();
        _systemUnderTest = new CustomerService(_repoMock.Object);
    }

    [Fact]
    async public Task GetAllCustomers_ReturnNotNull_AssertTrue()
    {
        Assert.NotNull(_systemUnderTest.GetAllCustomersService());
    }

    [Fact]
    async public Task AddCustomerService_CapitalizeFirstWords_AssertTrue()
    {
        Customer customer = new Customer
        {
            CustomerName = "jOhn sMiTh"
        };

        await _systemUnderTest.AddCustomerService(customer);
        _output.WriteLine(customer.CustomerName);

        Assert.Equal("John Smith", customer.CustomerName);
    }

}