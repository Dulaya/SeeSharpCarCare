namespace SeeSharpCarCare.Core.Data;

// Use Generic T because add customer, vehicle, etc. 
// to database is exactly same process except for different type.
public interface IRepository<T>
{
    public Task<string> AddToRepository(T obj);
    public Task<string> RemoveFromRepository(T obj);
    public Task<string> RemoveByIdFromRepository(int id);
    public Task<string> UpdateRepository(T obj);
    public Task<T> FindByIdInRepository(string vin);
}
