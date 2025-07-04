using Application.Features.Results.PurchaseResults;
using MediatR;

namespace Application.Features.Queries.PurchaseQueries;

public class GetPurchaseByIdQuery : IRequest<List<GetPurchaseByIdQueryResult>>
{
    public string Id { get; set; }

    public GetPurchaseByIdQuery(string id)
    {
         Id = id;
    }
}