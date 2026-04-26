using Moq;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;
using Xunit.Abstractions;

namespace SeeSharpCarCare.Tests.Services;

public class VehicleServiceTests
{    
    private readonly ITestOutputHelper _output;

    private readonly Mock<IRepository<Vehicle>> _repoMock;

    private readonly VehicleService _systemUnderTest;

    public VehicleServiceTests()
    {
        _repoMock = new Mock<IRepository<Vehicle>>();
        _systemUnderTest = new VehicleService(_repoMock.Object);
    }

    [Fact]
    async public Task AddVehicleService_Valid_AssertTrue()
    {
        Vehicle vehicle = new Vehicle
        {
            VIN = "12345678901234567" // Length must be 17
        };
        Assert.NotNull(_systemUnderTest.AddVehicleService(vehicle));
    }

    [Fact]
    async public Task AddVehicleService_ConvertVINUppercase_AssertTrue()
    {
        Vehicle vehicle = new Vehicle
        {
            VIN = "abcdefghijklmnopq" // Length must be 17
        };
        await _systemUnderTest.AddVehicleService(vehicle);

        Assert.Equal("ABCDEFGHIJKLMNOPQ", vehicle.VIN);
    }

    [Fact]
    async public Task AddVehicleService_InvalidVINLengthTooLong_ThrowsArgumentException()
    {
        Vehicle vehicleInvalidVIN = new Vehicle
        {
            VIN = "1234567890ABCDEFGHIJKLMNOP" // Length must be 17
        };
        await Assert.ThrowsAsync<ArgumentException>(() => _systemUnderTest.AddVehicleService(vehicleInvalidVIN));
    }

    [Fact]
    async public Task AddVehicleService_InvalidVINLengthTooShort_ThrowsArgumentException()
    {
        Vehicle vehicleInvalidVIN = new Vehicle
        {
            VIN = "ABC" // Length must be 17
        };
        await Assert.ThrowsAsync<ArgumentException>(() => _systemUnderTest.AddVehicleService(vehicleInvalidVIN));
    }

 
}