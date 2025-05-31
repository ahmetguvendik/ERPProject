using Application.Features.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;


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
            UserName = request.Username
        };

        var response = await _userManager.CreateAsync(appUser, request.Password);
        if (!response.Succeeded)
        {
            var errors = string.Join(", ", response.Errors.Select(e => e.Description));
            throw new Exception($"Kullanıcı oluşturulamadı: {errors}");
        }

        var role = await _roleManager.FindByNameAsync("Staff");
        if (role == null)
        {
            var appRole = new AppRole { Name = "Staff" };
            await _roleManager.CreateAsync(appRole);
        }

        await _userManager.AddToRoleAsync(appUser, "Staff");

     
    }
}
