using Application.Features.Queries.JobTypeQueries;
using Application.Features.Results.JobTypeResults;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.JobTypeHandlers.Read;

public class GetJobTypeQueryHandler  : IRequestHandler<GetJobTypeQuery, List<GetJobTypeQueryResult>>
{
    private readonly IRepository<JobType> _repository;

    public GetJobTypeQueryHandler(IRepository<JobType> repository)
    {
         _repository = repository;
    }
    
    public async Task<List<GetJobTypeQueryResult>> Handle(GetJobTypeQuery request, CancellationToken cancellationToken)
    {
      var values = await _repository.GetAllAsync();
      return values.Select(x => new GetJobTypeQueryResult()
      { 
          
          Id = x.Id,
        Name = x.Name,
      }).ToList();
    }
}