using Application.Features.Results.PurchaseResults;
using MediatR;

namespace Application.Features.Queries.PurchaseQueries;

public class GetPurchaseByUserIdQuery : IRequest<List<GetPurchaseByUserIdQueryResult>>
{
    public string Id { get; set; }

    public GetPurchaseByUserIdQuery(string id)
    {
        Id = id;
    }
}