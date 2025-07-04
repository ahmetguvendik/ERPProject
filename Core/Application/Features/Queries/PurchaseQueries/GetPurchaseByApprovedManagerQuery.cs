using Application.Features.Results.PurchaseResults;
using MediatR;

namespace Application.Features.Queries.PurchaseQueries;

public class GetPurchaseByApprovedManagerQuery : IRequest<List<GetPurchaseByApprovedManagerQueryResult>>
{
    
}