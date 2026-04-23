using SeeSharpCarCare.API.DTOs;

namespace SeeSharpCarCare.API.Data;

public interface IWorkOrderTechnicianRepository
{
    Task UpdateWorkOrderTechnicianRepository(WorkOrderTechnicianDTO workOrderTechnicianDTO);
}