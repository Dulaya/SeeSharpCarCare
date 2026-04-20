using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SeeSharpCarCare.Core.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = new();

    async public Task<string> AddToRepository(T obj)
    {
        try
        {
            bool objFound = await _context.Set<T>().AnyAsync(o => o == obj);
            if (objFound) return $"{typeof(T).Name} Already Existed.";
            else
            {
                await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();
                return $"{typeof(T).Name} Added";
            }
        }
        catch (DbException e)
        {
            return e.Message;
        }
    }


    async public Task<string> RemoveFromRepository(T obj)
    {
        try
        {
            bool objFound = await _context.Set<T>().AnyAsync(o => o == obj);
            if (!objFound) return $"{typeof(T).Name} Doesn't Exist.";
            else
            {
                _context.Set<T>().Remove(obj);
                await _context.SaveChangesAsync();
                return $"{typeof(T).Name} Removed.";
            }
        }
        catch (DbException e)
        {
            return e.Message;
        }
    }

    async public Task<string> RemoveByIdFromRepository(int id)
    {
        try
        {
            T? obj = await _context.Set<T>().FindAsync(id);
            if (obj == null) return $"{typeof(T).Name} Doesn't Exist.";
            else
            {
                _context.Set<T>().Remove(obj);
                await _context.SaveChangesAsync();
                return $"{typeof(T).Name} Removed.";
            }
        }
        catch (DbException e)
        {
            return e.Message;
        }
    }

    async public Task<string> UpdateRepository(T obj)
    {
        try
        {
            bool objFound = await _context.Set<T>().AnyAsync(v => v == obj);
            if (!objFound) return $"{typeof(T).Name} Not Found.";
            else
            {

                await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();
                return $"{typeof(T).Name} Removed.";
            }
        }
        catch (DbException e)
        {
            return e.Message;
        }
    }

    async public Task<T> FindByIdInRepository(string id)
    {
        try
        {
            T? obj = await _context.Set<T>().FindAsync(id);
            if (obj != null) return obj;
            else return null;
        }
        catch
        {
            return null;
        }
    }

    async public Task<List<T>> GetAllFromRepository()
    {
        return await _context.Set<T>().Take(10).ToListAsync();
    }

}