using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.API.Models;

public class Technician
{
    [Key]
    public required string Id { get; set; }

    public string? Name { get; set; }

    public List<Invoice>? Invoices { get; set; } = new List<Invoice>();

    public List<WorkOrder>? WorkOrders {get; set;} = new List<WorkOrder>();


}