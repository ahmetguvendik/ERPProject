using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

public class UpdateHrLeaveRequestCommandHandler : IRequestHandler<UpdateHrLeaveRequestCommand>
{
    private readonly IRepository<LeaveRequest> _leaveRequestRepository;
    private readonly ILeaveQuotaRepository _leaveQuotaRepository;

    public UpdateHrLeaveRequestCommandHandler(IRepository<LeaveRequest> leaveRequestRepository, ILeaveQuotaRepository leaveQuotaRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveQuotaRepository = leaveQuotaRepository;
    }

    public async Task Handle(UpdateHrLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        leaveRequest.Status = "IK Onayladi"; // "IK Onayladi" gibi

        if (leaveRequest.Status == "IK Onayladi")
        {
            int requestedDays = (leaveRequest.EndDate - leaveRequest.StartDate).Days + 1;

            var quotaList = await _leaveQuotaRepository.GetByUserIdAsync(leaveRequest.EmployeeId);
            var matchedQuota = quotaList.FirstOrDefault(q => q.RequestType == leaveRequest.Type && q.Year == DateTime.Now.Year);

            if (matchedQuota == null)
                throw new Exception("İzin kotası bulunamadı.");

            if (matchedQuota.AllowedDays - matchedQuota.UsedDays < requestedDays)
                throw new Exception("Yeterli izin hakkı yok.");

            matchedQuota.UsedDays += requestedDays;

            await _leaveQuotaRepository.UpdateAsync(matchedQuota);
        }

        await _leaveRequestRepository.UpdateAsync(leaveRequest);
        await _leaveRequestRepository.SaveAsync();
    }
}