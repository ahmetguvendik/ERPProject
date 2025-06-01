using Application.Features.Results.LeaveQuotaResults;
using MediatR;

namespace Application.Features.Queries.LeaveQuotaQueries;

public class GetLeaveQuotaQuery : IRequest<GetLeaveQuotaQueryResult>
{
    public string Id { get; set; }

    public GetLeaveQuotaQuery(string id)
    {
         Id = id;
    }
}