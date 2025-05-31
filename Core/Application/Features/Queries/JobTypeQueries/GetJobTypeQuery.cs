using Application.Features.Results.JobTypeResults;
using MediatR;

namespace Application.Features.Queries.JobTypeQueries;

public class GetJobTypeQuery : IRequest<List<GetJobTypeQueryResult>>
{
    
}