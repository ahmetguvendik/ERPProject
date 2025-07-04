using Application.Features.Queries.PurchaseQueries;
using Application.Features.Results.PurchaseResults;
using Application.Repostitories;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Read;

public class GetPurchaseByApprovedManagerQueryHandler : IRequestHandler<GetPurchaseByApprovedManagerQuery, List<GetPurchaseByApprovedManagerQueryResult>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetPurchaseByApprovedManagerQueryHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    public async Task<List<GetPurchaseByApprovedManagerQueryResult>> Handle(GetPurchaseByApprovedManagerQuery request, CancellationToken cancellationToken)
    {
        var values = await _purchaseRepository.GetPurchaseRequestsByApprovedManager();
        return values.Select(x=>new GetPurchaseByApprovedManagerQueryResult
        {
            Id = x.Id,
            Items = x.Items.Select(item => new PurchaseRequestItem
            {
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                Description = item.Description
            }).ToList(),
            Reason = x.Reason,
            Status = x.Status,
            CreatedAt = x.CreatedAt,
            UrgencyLevel = x.UrgencyLevel,
            Username = x.User.FirstName + " " + x.User.LastName,
            ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
            ApprovedAt = x.ApprovedAt,
            RejectionReason = x.RejectionReason,
        }).ToList();
    }
}