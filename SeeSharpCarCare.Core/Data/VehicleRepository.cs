using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.Core.Models;

namespace SeeSharpCarCare.Core.Data;

public class VehicleRepository
{
    private SeeSharpCarCareDbContext _context = new();

    async public Task<string> AddVehicleRepo(Vehicle vehicle)
    {
        try
        {
            bool vehicleFound = await _context.Vehicles.AnyAsync(v => v == vehicle);
            if (vehicleFound) return "Vehicle Already Existed.";
            else
            {
                await _context.Vehicles.AddAsync(vehicle);
                await _context.SaveChangesAsync();
                return "Vehicle Added";
            }
        }
        catch (DbException e)
        {
            return e.Message;
        }
    }

    async public Task<string> RemoveVehicleRepo(Vehicle vehicle)
    {
        try
        {
            bool vehicleFound = await _context.Vehicles.AnyAsync(v => v == vehicle);
            if (!vehicleFound) return "Vehicle Doesn't Exist.";
            else
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return "Vehicle Removed";
            }
        }
        catch (DbException e)
        {
            return e.Message;
        }
    }

    async public Task<string> UpdateVehicleRepo(Vehicle vehicle)
    {
        try
        {
            bool vehicleFound = await _context.Vehicles.AnyAsync(v => v == vehicle);
            if (!vehicleFound) return "Vehicle Not Found.";
            else
            {

                await _context.Vehicles.AddAsync(vehicle);
                await _context.SaveChangesAsync();
                return "Vehicle Removed.";
            }
        }
        catch (DbException e)
        {
            return e.Message;
        }
    }

    async public Task<Vehicle> FindVehicleByVINRepo(string vin)
    {
        try
        {
            Vehicle? vehicle = await _context.Vehicles.FindAsync(vin);
            if (vehicle != null) return vehicle;
            else return null;
        }
        catch
        {
            return null;
        }
    }


}