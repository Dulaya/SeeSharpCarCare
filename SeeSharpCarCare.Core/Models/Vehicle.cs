using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.Core.Models;

public class Vehicle
{
    [Key]
    public string VIN { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Body { get; set; }

    public string? Color { get; set; }

    public int? Year { get; set; }

    // public int? Mileage { get; set; }

    public List<Invoice> Invoices { get; set; } = new List<Invoice>();

    public List<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

}