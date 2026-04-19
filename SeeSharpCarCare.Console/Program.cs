using SeeSharpCarCare.Core.Data;
using SeeSharpCarCare.Core.Models;
using SeeSharpCarCare.Core.Services;

VehicleService vehicleService = new();

Vehicle vehicle = new Vehicle
{
    VIN = "jeugodlehgu7s9s01",
    Make = "Cadillac",
    Model = "Escalade",
    Body = "SUV",
    Color = "Black",
    Year = 2026,
};

// string add = await vehicleService.AddVehicleService(vehicle);
// string remove = await vehicleService.RemoveVehicleService(vehicle);
// string update = await vehicleService.UpdateVehicleService(vehicle);

// Vehicle? ford = await vehicleService.FindVehicleByVINService("7A8DH40DG8H34G8G");

// Console.WriteLine($"{ford.Make} {ford.Model} {ford.VIN}");

Repository<Customer> cust = new();
Customer c = new Customer
{
    CustomerName = "Timothy Valentine",
    Phone = "741-963-0258",
    Address = "9865 S. Pearl St. Seattle, WA. 98562",
    Email = "Timothy.Valentine@professionalservicexyz.io"
};
await cust.AddToRepository(c);


