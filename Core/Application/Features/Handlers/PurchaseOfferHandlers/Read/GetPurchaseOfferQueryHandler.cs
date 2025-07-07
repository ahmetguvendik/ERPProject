using Application.Features.Queries.PurchaseOfferQueries;
using Application.Features.Results.PurchaseOfferResults;
using Application.Repostitories;
using MediatR;

namespace Application.Features.Handlers.PurchaseOfferHandlers.Read;

public class GetPurchaseOfferQueryHandler : IRequestHandler<GetPurchaseOfferQuery, List<GetPurchaseOfferQueryResult>>
{
    private readonly IPurchaseOfferRepository _repository;

    public GetPurchaseOfferQueryHandler(IPurchaseOfferRepository repository)
    {
         _repository = repository;
    }
    
    public async Task<List<GetPurchaseOfferQueryResult>> Handle(GetPurchaseOfferQuery request, CancellationToken cancellationToken)
    {

        var values = await _repository.GetPurchaseOfferById(request.Id);
        return values.Select(x=> new  GetPurchaseOfferQueryResult
        {
            Id = x.Id,
            CompanyName = x.CompanyName,
            Amount = x.Amount,
            Description = x.Description,
            CreatedAt = x.CreatedAt,
            IsApproved = x.IsApproved,
            
        }).ToList();
    }
}