using Domain.Enums;
using MediatR;

namespace Application.Features.Commands;

public class CreateUserCommand : IRequest
{
    public string TCNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; } 
    public DateTime StartingJob { get; set; }
    public string DepartmanId { get; set; }
    public string JobTitle { get; set; }
    public string JobTypeId { get; set; }
    public string SicilNo { get; set; }
    public decimal BrutSalary { get; set; }
    public decimal NetSalary { get; set; }
    public string Iban { get; set; }
    public decimal Prim { get; set; }
    public decimal Disruptions { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string ManagerId { get; set; }
    public string RoleId { get; set; }    
}