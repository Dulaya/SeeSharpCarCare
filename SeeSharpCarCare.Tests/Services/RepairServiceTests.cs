using Moq;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;
using Xunit.Abstractions;

namespace SeeSharpCarCare.Tests.Services;

public class RepairServiceTests
{
    private readonly ITestOutputHelper _output;

    private readonly Mock<IRepository<Repair>> _repoMock;

    private readonly RepairService _systemUnderTest;

    public RepairServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _repoMock = new Mock<IRepository<Repair>>();
        _systemUnderTest = new RepairService(_repoMock.Object);
    }

    [Fact]
    async public Task AddRepairServiceToRepo_Valid_Verify()
    {
        Repair repair = new Repair
        {
            Id = 1,
            WorkOrderId = 5,
            RepairCode = "OC"
        };

        _output.WriteLine(repair.RepairCode);
        await _systemUnderTest.AddRepairService(repair);

        var sourceList = new List<Repair>();
        var mockSet = new Mock<IRepairService>();
        mockSet.Setup(m => m.AddRepairService(It.IsAny<Repair>()));

        _repoMock.Verify(m => m.AddToRepository(It.Is<Repair>(u => u.RepairCode == "OC")), Times.Once());
    }

    [Fact]
    async public Task AddAndRemoveRepairServiceToRepo_Valid_Verify()
    {
        Repair repair = new Repair
        {
            Id = 1,
            WorkOrderId = 5,
            RepairCode = "OC"
        };

        _output.WriteLine(repair.RepairCode);
        await _systemUnderTest.AddRepairService(repair);

        var sourceList = new List<Repair>();
        var mockSet = new Mock<IRepairService>();
        mockSet.Setup(m => m.AddRepairService(It.IsAny<Repair>()));

        _repoMock.Verify(m => m.AddToRepository(It.Is<Repair>(u => u.RepairCode == "OC")), Times.Once());

        await _systemUnderTest.RemoveRepairByIdService(repair.Id);
        _repoMock.Verify(m => m.RemoveByIdFromRepository(repair.Id), Times.Once());
    }

    [Fact]
    async public Task AddRepairServiceToRepo_Invalid_Verify()
    {
        Repair repair = new Repair
        {
            Id = -1,
            WorkOrderId = 5,
            RepairCode = "OC"
        };

        _output.WriteLine(repair.RepairCode);
        await _systemUnderTest.AddRepairService(repair);

        var sourceList = new List<Repair>();
        var mockSet = new Mock<IRepairService>();
        mockSet.Setup(m => m.AddRepairService(It.IsAny<Repair>()));

        _repoMock.Verify(m => m.AddToRepository(It.Is<Repair>(u => u.RepairCode == "OC")), Times.Once());
    }

    [Fact]
    async public Task FindRepairService_Invalid_ThrowsKeyNotFoundException()
    {
        Repair repair = new Repair
        {
            Id = 1,
            RepairCode = "OC"
        };
        await _systemUnderTest.AddRepairService(repair);
        await Assert.ThrowsAsync<KeyNotFoundException>(
         () => _systemUnderTest.FindRepairByIdService(-1));
    }
}