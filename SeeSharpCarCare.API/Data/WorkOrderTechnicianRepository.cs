using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.API.DTOs;

namespace SeeSharpCarCare.API.Data;

public class WorkOrdeTechnicianRepository : IWorkOrderTechnicianRepository
{
    private readonly ApplicationDbContext _context;

    public WorkOrdeTechnicianRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    async public Task UpdateWorkOrderTechnicianRepository(WorkOrderTechnicianDTO obj)
    {
        try
        {

            // bool workOrderFound = await _context.WorkOrders.AnyAsync(v => v.Id == obj.WorkOrderId);
            // if (!workOrderFound) throw new KeyNotFoundException("Work Order Not Found.");

            // bool technicianFound = await _context.Technicians.AnyAsync(t => t.Id == obj.TechnicianId);
            // if (!technicianFound) throw new KeyNotFoundException("Technician Not Found.");

            // await _context.TechnicianWorkOrders
            // .Where(wo => wo.WorkOrderId == obj.WorkOrderId)
            // .ExecuteUpdateAsync(setters => setters.SetProperty(t => t.TechnicianId, obj.TechnicianId));

            await _context.SaveChangesAsync();

        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

}