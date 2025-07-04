using Application.Features.Queries.PurchaseQueries;
using Application.Features.Results.PurchaseResults;
using Application.Repostitories;
using MediatR;

public class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, List<GetPurchaseByIdQueryResult>>
{
    private readonly IPurchaseRequestItemRepository _repository;

    public GetPurchaseByIdQueryHandler(IPurchaseRequestItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetPurchaseByIdQueryResult>> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetById(request.Id);

        if (items == null)
            throw new Exception("Satın alma talebi bulunamadı.");

        return items.Select(x => new GetPurchaseByIdQueryResult
        {
            Id = x.Id,
            ProductName = x.ProductName,
            Quantity = x.Quantity,
            Description = x.Description
        }).ToList();
    }
}