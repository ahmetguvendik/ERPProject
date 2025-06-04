using Application.Features.Results.LeaveRequestResults;
using MediatR;

namespace Application.Features.Queries.LeaveRequestQueries;

public class GetLeaveRequestByManagerIdQuery : IRequest<List<GetLeaveRequestByManagerIdQueryResult>>
{
    public string Id { get; set; }

    public GetLeaveRequestByManagerIdQuery(string id)
    {
         Id = id;
    }
}