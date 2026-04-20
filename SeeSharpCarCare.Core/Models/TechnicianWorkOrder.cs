using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.Core.Models;

public class TechnicianWorkOrder
{
    [Key]
    public int Id { get; set; }
    public int? TechnicianId { get; set; }

    public int? WorkOrderId { get; set; }

    //  public Technician Technician { get; set; } = null!;

    // public WorkOrder WokOrder { get; set; } = null!;

    //public List<WorkOrder>? WorkOrders { get; set; }
}