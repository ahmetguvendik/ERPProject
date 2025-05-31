using Application.Features.Queries.DepartmanQueries;
using Application.Features.Results.DepartmanResults;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.DepartmanHandlers.Read;

public class GetDepartmanQueryHandler  : IRequestHandler<GetDepartmanQuery, List<GetDepartmanQueryResult>>
{
    private readonly IRepository<Departman> _repository;

    public GetDepartmanQueryHandler(IRepository<Departman> repository)
    {
         _repository = repository;
    }
    
    public async Task<List<GetDepartmanQueryResult>> Handle(GetDepartmanQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetDepartmanQueryResult()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}