using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers.Write;

public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand>
{
    private readonly IRepository<LeaveRequest>  _leaveRequestRepository;
    private readonly ILeaveQuotaRepository  _leaveQuotaRepository;

    public CreateRequestCommandHandler(IRepository<LeaveRequest> leaveRequestRepository, ILeaveQuotaRepository leaveQuotaRepository)
    {
         _leaveRequestRepository = leaveRequestRepository;
         _leaveQuotaRepository = leaveQuotaRepository;
    }
    
    public async Task Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = new LeaveRequest();
        leaveRequest.Id = Guid.NewGuid().ToString();
        leaveRequest.CreatedAt = DateTime.Now;
        leaveRequest.Status = "Beklemede";
        leaveRequest.StartDate = request.StartDate;
        leaveRequest.EndDate = request.EndDate;
        leaveRequest.EmployeeId  = request.EmployeeId;
        leaveRequest.ManagerId   = request.ManagerId;
        leaveRequest.Type = request.RequestType;
        
        
        int requestedDays = (leaveRequest.EndDate - leaveRequest.StartDate).Days + 1;

        // LeaveQuota'yı getir
        var quota = await _leaveQuotaRepository.GetByUserIdAsync(request.EmployeeId);
        
        var matchedQuota = quota.FirstOrDefault(q => q.RequestType == request.RequestType && q.Year == DateTime.Now.Year);  

        if (matchedQuota == null)
        {
            throw new Exception("İzin kotası bulunamadı.");
        }

        // Yeterli izin var mı kontrol et
        if (matchedQuota.AllowedDays - matchedQuota.UsedDays < requestedDays)
        {
            throw new Exception("Yeterli izin hakkı yok.");
        }

        
        // UsedDays'e ekle
        matchedQuota.UsedDays += requestedDays;

        // Veritabanına hem LeaveRequest hem LeaveQuota kaydını kaydet
        await _leaveRequestRepository.CreateAsync(leaveRequest);
        await _leaveQuotaRepository.UpdateAsync(matchedQuota);

        await _leaveRequestRepository.SaveAsync();
    }
}