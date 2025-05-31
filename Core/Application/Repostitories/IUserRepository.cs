using Domain.Entities;

namespace Application.Repostitories;

public interface IUserRepository
{
    Task<AppUser> GetUserByTcNo(string tcNo);       

}