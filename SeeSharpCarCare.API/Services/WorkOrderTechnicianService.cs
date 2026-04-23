using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.DTOs;

namespace SeeSharpCarCare.API.Services;

public class WorkOrderTechnicianService : IWorkOrderTechnicianService
{
    private readonly IWorkOrderTechnicianRepository _workOrderTechnicianRepository;

    public WorkOrderTechnicianService(IWorkOrderTechnicianRepository workOrderRepository)
    {
        _workOrderTechnicianRepository = workOrderRepository;
    }

    async public Task UpdateWorkOrderTechnicianDTOService(WorkOrderTechnicianDTO workOrderTechnicianDTO)
    {
        try
        {

            await _workOrderTechnicianRepository.UpdateWorkOrderTechnicianRepository(workOrderTechnicianDTO);
        }
        catch
        {
            throw new KeyNotFoundException("Work Order Not Found.");
        }
    }

}