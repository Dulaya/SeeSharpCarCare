using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.Core.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public string? Email { get; set; }

    public List<Invoice> Invoices { get; set; } = new List<Invoice>();

    public List<WorkOrder> WordkOrders { get; set; } = new List<WorkOrder>();

}