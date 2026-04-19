using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.Core.Models;

namespace SeeSharpCarCare.Core.Data;

public class VehicleRepository
{
    SeeSharpCarCareDbContext context = new();

    async public Task<string> AddVehicle(Vehicle vehicle)
    {
        try
        {
            var vehicleFound = await context.Vehicles.AnyAsync(v => v == vehicle);
            if (vehicleFound) return "Vehicle Already Existed.";
            else
            {
                await context.Vehicles.AddAsync(vehicle);
                await context.SaveChangesAsync();
                return "Vehicle Added";
            }
        }
        catch (DbException e)
        {
            Console.WriteLine(e.Message);
            return e.Message;
        }
    }

    async public Task<string> RemoveVehicle(Vehicle vehicle)
    {
        try
        {
            var vehicleFound = await context.Vehicles.AnyAsync(v => v == vehicle);
            if (!vehicleFound) return "Vehicle Doesn't Exist.";
            else
            {
                context.Vehicles.Remove(vehicle);
                await context.SaveChangesAsync();
                return "Vehicle Removed";
            }
        }
        catch (DbException e)
        {
            Console.WriteLine(e.Message);
            return e.Message;
        }
    }
}