using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.API.Models;

public class Invoice
{
    [Key]
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public Customer? Customer { get; set; } = null!;

    public string? VIN { get; set; } = null!;

    public Vehicle? Vehicle { get; set; } = null!;

    public DateTime? RepairDate { get; set; } = DateTime.Now;

    public List<Repair>? Repairs { get; set; } = new List<Repair>();

    public int? WorkOrderId {get; set;}

    public WorkOrder? WorkOrder { get; set; } = null!;
}