using Application.Features.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Handlers.AppUserHandlers.Write;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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
            // Rol bulunamadı, hata verebilirsin ya da yeni rol eklemek istersen ekleyebilirsin.
            // Ama sen roller zaten elle ekleniyor demiştin, o yüzden hata dönmek mantıklı olabilir.
            throw new Exception("Role not found.");
        }

        // Rol bulunduysa kullanıcıyı o role ekle
        await _userManager.AddToRoleAsync(appUser, role.Name);
        
    }
}
