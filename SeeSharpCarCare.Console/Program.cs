using SeeSharpCarCare.Core.Data;
using SeeSharpCarCare.Core.Models;
using SeeSharpCarCare.Core.Services;

VehicleService vehicleService = new();

Vehicle vehicle = new Vehicle
{
    VIN = "59dj3hvkdlg04vydf",
    Make = "GMC",
    Model = "Yukon Denali",
    Body = "SUV",
    Color = "Turquois",
    Year = 2025,
};

// string add = await vehicleService.AddVehicle(vehicle);
string remove = await vehicleService.RemoveVehicle(vehicle);
Console.WriteLine(remove);



