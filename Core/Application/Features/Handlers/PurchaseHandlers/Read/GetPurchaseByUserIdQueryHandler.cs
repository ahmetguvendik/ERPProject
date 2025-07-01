using Application.Features.Queries.PurchaseQueries;
using Application.Features.Results.PurchaseResults;
using Application.Repostitories;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Read;

public class GetPurchaseByUserIdQueryHandler : IRequestHandler<GetPurchaseByUserIdQuery, List<GetPurchaseByUserIdQueryResult>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchaseByUserIdQueryHandler(IPurchaseRepository purchaseRepository)
    {
         _purchaseRepository = purchaseRepository;
    }
    
    public async Task<List<GetPurchaseByUserIdQueryResult>> Handle(GetPurchaseByUserIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _purchaseRepository.GetPurchaseRequestsById(request.Id);
        return values.Select(x=> new GetPurchaseByUserIdQueryResult
        {
            ProductName = x.ProductName,
            Quantity = x.Quantity,
            Reason = x.Reason,
            Statues = x.Statues,
            CreatedAt = x.CreatedAt,
            UrgencyLevel = x.UrgencyLevel
        }).ToList();
    }
}