using Domain.Entities;

namespace Application.Repostitories;

public interface IPurchaseRepository
{
    Task<List<PurchaseRequest>> GetPurchaseRequestsById(string id);
}