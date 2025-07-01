using Application.Features.Commands;
using Application.Repostitories;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Handlers.AppUserHandlers.Write;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IRepository<LeaveQuota>  _leaveQuotaRepository;
    

    public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IRepository<LeaveQuota> leaveQuotaRepository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _leaveQuotaRepository = leaveQuotaRepository;
    }
    
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var appUser = new AppUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            TCNo = request.TCNo,
            BirthDate = request.BirthDate,
            Gender = request.Gender,
            JobTitle = request.JobTitle,
            JobTypeId = request.JobTypeId,
            SicilNo = request.SicilNo,
            BrutSalary = request.BrutSalary,
            StartingJob = request.StartingJob,
            NetSalary = request.NetSalary,
            Disruptions = request.Disruptions,
            Iban = request.Iban,
            Prim = request.Prim,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            DepartmanId = request.DepartmanId,
            UserName = request.Username,
            IsActive = true,
            ManagerId = request.ManagerId, 
            
        };

        var response = await _userManager.CreateAsync(appUser, request.Password);
        if (!response.Succeeded)
        {
            var errors = string.Join(", ", response.Errors.Select(e => e.Description));
            throw new Exception($"Kullanıcı oluşturulamadı: {errors}");
        }

        var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == request.RoleId);
        if (role == null)
        {
            throw new Exception("Role not found.");
        }

        var leaveQuota = new LeaveQuota
        {
            Id = Guid.NewGuid().ToString(),
            Year = DateTime.Now.Year,
            EmployeeId = appUser.Id,
            AllowedDays = 14, 
            RequestType = RequestType.Yillik,
            UsedDays = 0
        };

        var leaveQuota1 = new LeaveQuota
        {
            Id = Guid.NewGuid().ToString(),
            Year = DateTime.Now.Year,
            EmployeeId = appUser.Id,
            AllowedDays = 20, 
            RequestType = RequestType.Ucretsiz,
            UsedDays = 0
        };
        
        var leaveQuota2 = new LeaveQuota
        {
            Id = Guid.NewGuid().ToString(),
            Year = DateTime.Now.Year,
            EmployeeId = appUser.Id,
            AllowedDays = 3, 
            RequestType = RequestType.Evlilik,
            UsedDays = 0
        };
        
        var leaveQuota3 = new LeaveQuota
        {
            Id = Guid.NewGuid().ToString(),
            Year = DateTime.Now.Year,
            EmployeeId = appUser.Id,
            AllowedDays = 5, 
            RequestType = RequestType.Dogum,
            UsedDays = 0
        };

               
        var leaveQuota4 = new LeaveQuota
        {
            Id = Guid.NewGuid().ToString(),
            Year = DateTime.Now.Year,
            EmployeeId = appUser.Id,
            AllowedDays = 5, 
            RequestType = RequestType.Olum,
            UsedDays = 0
        };
        
                     
        var leaveQuota5 = new LeaveQuota
        {
            Id = Guid.NewGuid().ToString(),
            Year = DateTime.Now.Year,
            EmployeeId = appUser.Id,
            AllowedDays = 1, 
            RequestType = RequestType.DogumGunu,
            UsedDays = 0
        };

        await _leaveQuotaRepository.CreateAsync(leaveQuota);
        await _leaveQuotaRepository.CreateAsync(leaveQuota1);
        await _leaveQuotaRepository.CreateAsync(leaveQuota2);
        await _leaveQuotaRepository.CreateAsync(leaveQuota3);
        await _leaveQuotaRepository.CreateAsync(leaveQuota4);
        await _leaveQuotaRepository.CreateAsync(leaveQuota5);
        await _leaveQuotaRepository.SaveAsync();
        await _userManager.AddToRoleAsync(appUser, role.Name);
        
    }
}
