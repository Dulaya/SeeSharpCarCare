using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.Core.Models;

public class RepairCode
{
    [Key]
    public string Id { set; get; }

    public string? RepairName { get; set; }
}