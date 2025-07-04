using Domain.Entities;

namespace Application.Repostitories;

public interface IPurchaseRequestItemRepository
{
    Task<List<PurchaseRequestItem>> GetById(string id);  
}