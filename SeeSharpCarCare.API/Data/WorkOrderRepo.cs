using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Data;

public interface IWorkOrderRepo
{
    public Task UpdateWorkOrderRepo(WorkOrder obj);
    public Task<WorkOrder> FindWorkOrderByIdInRepo(int id);
    Task<List<WorkOrder>> GetAllWorkOrdersFromRepo();
}

public class WorkOrderRepo : IWorkOrderRepo
{
    private readonly ApplicationDbContext _context;

    public WorkOrderRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    async public Task<List<WorkOrder>> GetAllWorkOrdersFromRepo()
    {
        await _context.Customers.ToListAsync();
        return await _context.WorkOrders.ToListAsync();
    }

    async public Task<WorkOrder> FindWorkOrderByIdInRepo(int id)
    {
        try
        {
            IEnumerable<TechnicianWorkOrder> matchedTWO = _context.TechnicianWorkOrders
                                                .Where(tw => tw.WorkOrderId == id);

            List<Technician> technicians = new();

            foreach (Technician technician in _context.Technicians.ToList())
            {
                foreach (TechnicianWorkOrder technicianWorkOrder in matchedTWO)
                {
                    if (technician.Id == technicianWorkOrder.TechnicianId)
                        // technicians.Add(new Technician { Id = technicianWorkOrder.TechnicianId, Name = technician.Name });
                        technicians.Add(technician);
                }
            }

            WorkOrder? workOrder = await _context.WorkOrders.FindAsync(id);
            workOrder.Technicians = technicians;

            workOrder.Repairs = _context.Repairs.Where(r => r.WorkOrderId == workOrder.Id).ToList();

            if (workOrder != null) return workOrder;
            else throw new KeyNotFoundException("Id Not Found.");
        }
        catch
        {
            throw new KeyNotFoundException("Id Not Found.");
        }
    }

    async public Task UpdateWorkOrderRepo(WorkOrder obj)
    {
        try
        {
            WorkOrder? foundWO = await _context.WorkOrders.FindAsync(obj.Id);

            IEnumerable<TechnicianWorkOrder> technicianWorkOrders =
            _context.TechnicianWorkOrders
            .Where(two => two.WorkOrderId == obj.Id);

            if (foundWO is not null)
            {
                foundWO.VIN = obj.VIN;
                foundWO.CustomerId = obj.CustomerId;
                foundWO.Repairs = obj.Repairs;

                Console.WriteLine(foundWO.VIN);
                // Add Technicians
                if (obj.Technicians is not null)
                {
                    foreach (var t in obj.Technicians)
                    {
                        Technician? foundTech = await _context.Technicians.FindAsync(t.Id);
                        Console.WriteLine(foundTech.Name);
                        if (technicianWorkOrders.Count() > 0)
                        {
                            foreach (var a in technicianWorkOrders)
                                if (foundTech is not null && a.TechnicianId != foundTech.Id)
                                    foundWO.Technicians.AddRange(foundTech);
                        }
                        else
                            foreach (var a in obj.Technicians)
                                foundWO.Technicians.AddRange(foundTech);
                    }
                }

            }
            await _context.SaveChangesAsync();
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

}