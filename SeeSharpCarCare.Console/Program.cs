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
    Color = "White",
    Year = 1997,
};

// string add = await vehicleService.AddVehicleService(vehicle);
// string remove = await vehicleService.RemoveVehicleService(vehicle);
// string update = await vehicleService.UpdateVehicleService(vehicle);

Vehicle? ford = await vehicleService.FindVehicleByVINService("7A8DH40DG8H34G8G");

Console.WriteLine($"{ford.Make} {ford.Model} {ford.VIN}");



