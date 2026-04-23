using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.API.Models;

public class TechnicianWorkOrder
{
    [Key]
    public int Id { get; set; }
    public string? TechnicianId { get; set; }

    public int? WorkOrderId { get; set; }

    //  public Technician Technician { get; set; } = null!;

    // public WorkOrder WokOrder { get; set; } = null!;

    //public List<WorkOrder>? WorkOrders { get; set; }
}