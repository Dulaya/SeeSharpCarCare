using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Data;

public class TechWorkOrderRepository : ITechWorkOrderRepository
{
    private readonly ApplicationDbContext _context;

    public TechWorkOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    async public Task UpdateTechWorkOrderRepository(TechWorkOrderDTO obj)
    {
        try
        {
            await _context.TechnicianWorkOrders
            .Where(wo => wo.WorkOrderId == obj.WorkOrderId)
            .ExecuteUpdateAsync(setters =>
            {
                setters.SetProperty(t => t.TechnicianId, obj.TechnicianId);
            });

            await _context.TechnicianWorkOrders
            .Where(t => t.TechnicianId == obj.TechnicianId)
            .ExecuteUpdateAsync(setters =>
            {
                setters.SetProperty(wo => wo.WorkOrderId, obj.WorkOrderId);
            });
            await _context.SaveChangesAsync();
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

}