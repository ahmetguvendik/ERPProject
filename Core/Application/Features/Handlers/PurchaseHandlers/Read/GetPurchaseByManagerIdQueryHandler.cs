using Application.Features.Queries.PurchaseQueries;
using Application.Features.Results.PurchaseResults;
using Application.Repostitories;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Read;

public class GetPurchaseByManagerIdQueryHandler : IRequestHandler<GetPurchaseByManagerIdQuery, List<GetPurchaseByManagerIdQueryResult>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchaseByManagerIdQueryHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    public async Task<List<GetPurchaseByManagerIdQueryResult>> Handle(GetPurchaseByManagerIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _purchaseRepository.GetPurchaseRequestsByManagerId(request.Id);
        return values.Select(x=>new GetPurchaseByManagerIdQueryResult
        {
            ProductName = x.ProductName,
            Quantity = x.Quantity,
            Reason = x.Reason,
            Statues = x.Statues,
            CreatedAt = x.CreatedAt,
            UrgencyLevel = x.UrgencyLevel,
            Username = x.User.FirstName + " " + x.User.LastName
        }).ToList();
    }
}