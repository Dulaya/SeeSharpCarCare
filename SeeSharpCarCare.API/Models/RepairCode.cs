using System.ComponentModel.DataAnnotations;

namespace SeeSharpCarCare.API.Models;

public class RepairCode
{
    [Key]
    public string Id { set; get; }

    public string? RepairName { get; set; }
}