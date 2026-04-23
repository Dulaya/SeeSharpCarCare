using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.DTOs;

namespace SeeSharpCarCare.API.Services;

public class TechWorkOrderService : ITechWorkOrderService
{
    private readonly ITechWorkOrderRepository _techWorkOrderRepository;

    public TechWorkOrderService(ITechWorkOrderRepository techWorkOrderRepository)
    {
        _techWorkOrderRepository = techWorkOrderRepository;
    }

    async public Task UpdateTechWorkOrderDTOService(TechWorkOrderDTO techWorkOrderDTO)
    {
        try
        {

            await _techWorkOrderRepository.UpdateTechWorkOrderRepository(techWorkOrderDTO);
        }
        catch
        {
            throw new KeyNotFoundException("Work Order Not Found.");
        }
    }

}