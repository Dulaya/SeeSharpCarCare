using Moq;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;
using Xunit.Abstractions;

namespace SeeSharpCarCare.Tests.Services;

public class TechnicianServiceTests
{
    private readonly ITestOutputHelper _output;

    private readonly Mock<IRepository<Technician>> _repoMock;

    private readonly TechnicianService _systemUnderTest;

    public TechnicianServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _repoMock = new Mock<IRepository<Technician>>();
        _systemUnderTest = new TechnicianService(_repoMock.Object);
    }

    [Fact]
    async public Task AddTechnicianService_CapitalizeFirstWords_AssertTrue()
    {
        Technician technician = new Technician
        {
            Id = "TEC001",
            Name = "gEorGe wAsHinGtON"
        };

        await _systemUnderTest.AddTechnicianService(technician);
        _output.WriteLine(technician.Name);

        Assert.Equal("George Washington", technician.Name);
    }

}