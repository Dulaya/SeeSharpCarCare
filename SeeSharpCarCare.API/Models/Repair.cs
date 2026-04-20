
using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.API.Models;

public class Repair
{
    [Key]
    public int Id { get; set; }

    public string? RepairCode { get; set; }

    public Technician? Technician { get; set; } = null;

    public int? TechnicianId { get; set; }

    public double? Cost { get; set; }

    public string? Details { get; set; }

    public int? WorkOrderId { get; set; }
    public WorkOrder? WorkOrder { get; set; } = null;

    public int? Mileage { get; set; }

}