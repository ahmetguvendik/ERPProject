using Application.Repostitories;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ERPDbContext  _context;

    public Repository(ERPDbContext context)
    { 
       _context = context;  
    }
    
    public async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task CreateAsync(T entity)
    {
      await _context.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
         _context.Remove(entity);
    }

    public async Task SaveAsync()
    {
       await _context.SaveChangesAsync();   
    }
}