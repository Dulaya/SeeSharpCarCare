using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Data;

public interface IWorkOrderRepo
{
    public Task UpdateWorkOrderRepo(WorkOrder obj);
    public Task<WorkOrder> FindWorkOrderByIdInRepo(int id);
}

public class WorkOrderRepo : IWorkOrderRepo
{
    private readonly ApplicationDbContext _context;

    public WorkOrderRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    async public Task<WorkOrder> FindWorkOrderByIdInRepo(int id)
    {
        try
        {
            var x = _context.TechnicianWorkOrders.Where(tw => tw.WorkOrderId == id);
            List<Technician> t = new();
            foreach (var a in x)
            {
                Console.WriteLine(a.TechnicianId);
                t.Add(new Technician { Id = a.TechnicianId });
            }

            WorkOrder? obj = await _context.WorkOrders.FindAsync(id);
            obj.Technicians = t;

            if (obj != null) return obj;
            else throw new KeyNotFoundException("Id Not Found.");
        }
        catch
        {
            throw new KeyNotFoundException("Id Not Found.");
        }
    }

    async public Task UpdateWorkOrderRepo(WorkOrder obj)
    {
        Console.WriteLine(obj.Technicians.Count);
        try
        {
            Console.WriteLine("begin");
            WorkOrder? foundWO = await _context.WorkOrders.FindAsync(obj.Id);
            //foundWO.Technicians.Add(new Technician { Name = "hi", Id = "TEC003" });

            Console.WriteLine("end");
            if (foundWO is not null)
            {
                foundWO.VIN = obj.VIN;
                foundWO.CustomerId = obj.CustomerId;
                if (obj.Technicians is not null)
                {
                    foreach (var t in obj.Technicians)
                    {
                        Technician? foundTech = await _context.Technicians.FindAsync(t.Id);
                        if (foundTech is not null) foundWO.Technicians.AddRange(foundTech);
                    }
                }
            }
            await _context.SaveChangesAsync();
            /*
            {
            "id": 1,
            "technicians": [{"id": "TEC001"},{"id": "TEC002"}]
            }
            */

        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

}