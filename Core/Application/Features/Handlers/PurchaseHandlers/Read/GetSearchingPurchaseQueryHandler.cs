using Application.Features.Commands.PurchaseCommands;
using Application.Features.Queries.PurchaseQueries;
using Application.Features.Results.PurchaseResults;
using Application.Repostitories;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Read;

public class GetSearchingPurchaseQueryHandler : IRequestHandler<GetSearchingPurchaseQuery, List<GetSearchingPurchaseQueryResult>>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetSearchingPurchaseQueryHandler(IPurchaseRepository purchaseRepository)
    {
         _purchaseRepository = purchaseRepository;
    }
    
    public async Task<List<GetSearchingPurchaseQueryResult>> Handle(GetSearchingPurchaseQuery request, CancellationToken cancellationToken)
    {
        var values = await _purchaseRepository.GetSearchingPurchase();
        return values.Select(x=> new GetSearchingPurchaseQueryResult
        {
            Id = x.Id,
            Reason = x.Reason,
            Status = x.Status,
            UrgencyLevel = x.UrgencyLevel,
            Username = x.User.FirstName + " " + x.User.LastName,
            ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
            Items = x.Items?.Select(item => new PurchaseRequestItem
            {
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                Description = item.Description
            }).ToList() ?? new List<PurchaseRequestItem>()
        }).ToList();
    }
}