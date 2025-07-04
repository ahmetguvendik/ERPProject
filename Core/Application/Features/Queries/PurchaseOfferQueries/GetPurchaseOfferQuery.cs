using Application.Features.Results.PurchaseOfferResults;
using MediatR;

namespace Application.Features.Queries.PurchaseOfferQueries;

public class GetPurchaseOfferQuery : IRequest<List<GetPurchaseOfferQueryResult>>
{
    public string Id { get; set; }

    public GetPurchaseOfferQuery(string id)
    {
         Id = id;
    }
}