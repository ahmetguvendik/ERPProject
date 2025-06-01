using Application.Repostitories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ERPDbContext _context;


    public UserRepository(ERPDbContext context )
    {
        _context = context;
    }
    
    public async Task<AppUser> GetUserByTcNo(string tcNo)
    {
        var value =  _context.Users.Where(x => x.TCNo == tcNo).FirstOrDefault();
        return value;
    }

    public async Task<AppUser> GetUserById(string id)
    {
            return (await _context.Users
                .Include(x => x.Departman)
                .Include(x => x.JobType)
                .Include(x => x.Manager) 
                .FirstOrDefaultAsync(x => x.Id == id))!;    
            
    }
}