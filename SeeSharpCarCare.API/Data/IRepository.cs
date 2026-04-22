using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Data;

// Use Generic T because add customer, vehicle, etc. 
// to database is exactly same process except for different type.
public interface IRepository<T>
{
    public Task<T> AddToRepository(T obj);
    public Task<T> RemoveFromRepository(T obj);
    public Task RemoveByIdFromRepository(int id);
    public Task RemoveByIdFromRepository(string id);
    public Task UpdateRepository(T obj);
    public Task<T> FindByIdInRepository(int id);
    public Task<T> FindByIdInRepository(string vin);
}
