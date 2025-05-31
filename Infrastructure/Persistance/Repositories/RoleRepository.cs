using Application.Repostitories;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ERPDbContext _context;

    public RoleRepository(ERPDbContext context)
    {
         _context = context;
    }
    public async Task<IEnumerable<AppRole>> GetAllAsync()
    {
        var values = _context.Roles.ToList();
        return values;
    }

 
}