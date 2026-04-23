using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface IWorkOrderTechnicianService
{
    Task UpdateWorkOrderTechnicianDTOService(WorkOrderTechnicianDTO workOrderTechnicianDTO);

}
