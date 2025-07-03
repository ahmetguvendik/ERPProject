using Application.Features.Queries.PurchaseQueries;
using Application.Features.Results.PurchaseResults;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

public class GetPurchaseByManagerIdQueryHandler : IRequestHandler<GetPurchaseByManagerIdQuery, List<GetPurchaseByManagerIdQueryResult>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchaseByManagerIdQueryHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    public async Task<List<GetPurchaseByManagerIdQueryResult>> Handle(GetPurchaseByManagerIdQuery request, CancellationToken cancellationToken)
    {
        var purchases = await _purchaseRepository.GetPurchaseRequestsByManagerId(request.Id);

        return purchases.Select(pr => new GetPurchaseByManagerIdQueryResult
        {
            Id = pr.Id,
            Reason = pr.Reason,
            Status = pr.Status.ToString(),
            CreatedAt = pr.CreatedAt,
            UrgencyLevel = pr.UrgencyLevel,
            Username = pr.User.FirstName + " " + pr.User.LastName,
            Items = pr.Items.Select(item => new PurchaseRequestItem
            {
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                Description = item.Description
            }).ToList()
        }).ToList();
    }
}