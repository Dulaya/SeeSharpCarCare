using SeeSharpCarCare.API.DTOs;

namespace SeeSharpCarCare.API.Data;

public interface ITechWorkOrderRepository
{
    Task UpdateTechWorkOrderRepository(TechWorkOrderDTO techworkOrderDTO);
}