using SeeSharpCarCare.API.DTOs;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface ITechWorkOrderService
{
    Task UpdateTechWorkOrderDTOService(TechWorkOrderDTO techWorkOrderDTO);

}
