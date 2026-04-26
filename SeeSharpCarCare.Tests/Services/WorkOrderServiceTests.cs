using Moq;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;
using Xunit.Abstractions;

namespace SeeSharpCarCare.Tests.Services;

public class WorkOrderServiceTests
{
    private readonly ITestOutputHelper _output;

    private readonly Mock<IWorkOrderRepo> _repoMock;
    private readonly Mock<IRepository<WorkOrder>> _repoMockGeneric;

    private readonly WorkOrderService _systemUnderTest;

    public WorkOrderServiceTests()
    {
        _repoMockGeneric = new Mock<IRepository<WorkOrder>>();
        _repoMock = new Mock<IWorkOrderRepo>();
        _systemUnderTest = new WorkOrderService(_repoMockGeneric.Object, _repoMock.Object);
    }

    [Fact]
    async public Task FindWorkOrderService_Invalid_ThrowsKeyNotFoundException()
    {
        WorkOrder workOrder = new WorkOrder
        {
            Id = 1
        };
        await _systemUnderTest.AddWorkOrderService(workOrder);
        await Assert.ThrowsAsync<KeyNotFoundException>(
            () => _systemUnderTest.FindWorkOrderByIdService(-1));
    }


}