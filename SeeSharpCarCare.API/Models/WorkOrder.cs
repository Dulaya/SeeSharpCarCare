using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SeeSharpCarCare.API.DTOs;

namespace SeeSharpCarCare.API.Models;

public class WorkOrder
{
    [Key]
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public Customer? Customer { get; set; } = null!;

    public string? VIN { get; set; } = null!;

    public Vehicle? Vehicle { get; set; } = null!;

    public DateTime? RepairDate { get; set; } = DateTime.Now;

    public List<Technician> Technicians { get; set; } = new List<Technician>();

    public List<Repair>? Repairs { get; set; } = new List<Repair>();

    public Invoice? Invoice { get; set; } = null!;

    public int? InvoiceId { get; set; }

}