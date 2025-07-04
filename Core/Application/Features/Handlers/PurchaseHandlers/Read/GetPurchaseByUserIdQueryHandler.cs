using Application.Features.Commands.PurchaseCommands;
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
            Status = pr.Status,
            CreatedAt = pr.CreatedAt,
            UrgencyLevel = pr.UrgencyLevel,
            ApprovedAt = pr.ApprovedAt,
            RejectionReason = pr.RejectionReason,
            Items = pr.Items?.Select(item => new PurchaseRequestItemDto
            {
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                Description = item.Description
            }).ToList() ?? new List<PurchaseRequestItemDto>()
        }).ToList();
    }
}