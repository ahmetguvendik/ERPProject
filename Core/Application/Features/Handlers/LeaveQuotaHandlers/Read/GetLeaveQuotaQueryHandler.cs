using Application.Features.Queries.LeaveQuotaQueries;
using Application.Features.Results.LeaveQuotaResults;
using Application.Repostitories;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.LeaveQuotaHandlers.Read;

public class GetLeaveQuotaQueryHandler : IRequestHandler<GetLeaveQuotaQuery, List<GetLeaveQuotaQueryResult>>
{
    private readonly ILeaveQuotaRepository _leaveQuotaRepository;

    public GetLeaveQuotaQueryHandler(ILeaveQuotaRepository leaveQuotaRepository)
    {
         _leaveQuotaRepository = leaveQuotaRepository;
    }
        
    public async Task<List<GetLeaveQuotaQueryResult>> Handle(GetLeaveQuotaQuery request, CancellationToken cancellationToken)
    {
        var values = await _leaveQuotaRepository.GetByUserIdAsync(request.Id);
        return values.Select(x => new GetLeaveQuotaQueryResult
        {
            Id = x.Id,
            EmployeeId = x.EmployeeId,
            Year = x.Year,
            AllowedDays = x.AllowedDays,
            UsedDays = x.UsedDays,
            RequestType = x.RequestType,
        }).ToList();

    }
}