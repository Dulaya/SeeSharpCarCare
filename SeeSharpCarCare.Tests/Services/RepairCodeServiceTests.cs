using Moq;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

namespace SeeSharpCarCare.Tests.Services;

public class RepairCodeServiceTests
{
    private readonly Mock<IRepository<RepairCode>> _repoMock;

    private readonly RepairCodeService _systemUnderTest;

    public RepairCodeServiceTests()
    {
        _repoMock = new Mock<IRepository<RepairCode>>();
        _systemUnderTest = new RepairCodeService(_repoMock.Object);
    }

    [Fact]
    async public Task GetAllRepairCodes_ReturnNotNull_AssertTrue()
    {

        Assert.NotNull(_systemUnderTest.GetAllRepairCodesService());
    }

 
}