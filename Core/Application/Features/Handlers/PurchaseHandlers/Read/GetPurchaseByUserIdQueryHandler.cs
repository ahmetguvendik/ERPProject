using Application.Features.Queries.PurchaseQueries;
using Application.Features.Results.PurchaseResults;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

public class GetPurchaseByUserIdQueryHandler : IRequestHandler<GetPurchaseByUserIdQuery, List<GetPurchaseByUserIdQueryResult>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchaseByUserIdQueryHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    
    public async Task<List<GetPurchaseByUserIdQueryResult>> Handle(GetPurchaseByUserIdQuery request, CancellationToken cancellationToken)
    {
        var purchases = await _purchaseRepository.GetPurchaseRequestsById(request.Id);

        return purchases.Select(pr => new GetPurchaseByUserIdQueryResult
        {
            Id = pr.Id,
            Reason = pr.Reason,
            Status = pr.Status.ToString(),
            CreatedAt = pr.CreatedAt,
            UrgencyLevel = pr.UrgencyLevel,
            Items = pr.Items.Select(item => new PurchaseRequestItem
            {
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                Description = item.Description
            }).ToList()
        }).ToList();
    }
}