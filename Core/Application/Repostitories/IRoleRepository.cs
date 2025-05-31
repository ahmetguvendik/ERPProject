using Domain.Entities;

namespace Application.Repostitories;

public interface IRoleRepository
{
    Task<IEnumerable<AppRole>> GetAllAsync();
   
}