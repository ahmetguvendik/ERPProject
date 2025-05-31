using Application.Repostitories;
using Domain.Entities;
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
}