using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    async public Task<T> AddToRepository(T obj)
    {
        try
        {
            bool objFound = await _context.Set<T>().AnyAsync(o => o == obj);
            if (objFound) throw new DuplicateNameException("Id Already Existed.");
            else
            {
                await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }


    async public Task<T> RemoveFromRepository(T obj)
    {
        try
        {
            bool objFound = await _context.Set<T>().AnyAsync(o => o == obj);
            if (!objFound) throw new KeyNotFoundException("Id Not Found.");
            else
            {
                _context.Set<T>().Remove(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task RemoveByIdFromRepository(int id)
    {
        try
        {
            T? obj = await _context.Set<T>().FindAsync(id);
            if (obj == null) throw new KeyNotFoundException("Id Not Found.");
            else
            {
                _context.Set<T>().Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task RemoveByIdFromRepository(string id)
    {
        try
        {
            T? obj = await _context.Set<T>().FindAsync(id);
            if (obj == null) throw new KeyNotFoundException("Id Not Found.");
            else
            {
                _context.Set<T>().Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task UpdateRepository(T obj)
    {
        try
        {
            bool objFound = await _context.Set<T>().AnyAsync(v => v == obj);
            if (!objFound) throw new KeyNotFoundException("Id Not Found.");

            else
            {

                await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();
            }
        }
        catch (DbException e)
        {
            throw new Exception(e.Message);
        }
    }

    async public Task<T> FindByIdInRepository(int id)
    {
        try
        {
            T? obj = await _context.Set<T>().FindAsync(id);
            if (obj != null) return obj;
            else throw new KeyNotFoundException("Id Not Found.");
        }
        catch
        {
            throw new KeyNotFoundException("Id Not Found.");
        }
    }

    async public Task<T> FindByIdInRepository(string id)
    {
        try
        {
            T? obj = await _context.Set<T>().FindAsync(id);
            if (obj != null) return obj;
            else throw new KeyNotFoundException("Id Not Found.");
        }
        catch
        {
            throw new KeyNotFoundException("Id Not Found.");
        }
    }

    async public Task<List<T>> GetAllFromRepository()
    {
        return await _context.Set<T>().Take(10).ToListAsync();
    }

}