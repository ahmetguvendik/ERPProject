using Application.Features.Results.PurchaseResults;
using MediatR;

namespace Application.Features.Queries.PurchaseQueries;

public class GetPurchaseByManagerIdQuery : IRequest<List<GetPurchaseByManagerIdQueryResult>>
{
    public string Id { get; set; }

    public GetPurchaseByManagerIdQuery(string id)
    {
         Id = id;
    }
}