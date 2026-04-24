using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Services;

public interface ITechnicianService
{
    Task<Technician> AddTechnicianService(Technician technician);
    Task<Technician> RemoveTechnicianService(Technician technician);
    Task RemoveTechnicianByIdService(string id);
    Task UpdateTechnicianService(Technician technician);
    Task<Technician> FindTechnicianByIdService(string id);
}