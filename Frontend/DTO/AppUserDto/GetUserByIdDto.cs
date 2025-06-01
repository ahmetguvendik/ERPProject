using Domain.Enums;

namespace DTO.AppUserDto;

public class GetUserByIdDto
{
    public string Id { get; set; }
    public string TCNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }  
    public string PhoneNumber { get; set; } 
    public DateTime StartingJob { get; set; }
    public string DepartmanName { get; set; }
    public string JobTitle { get; set; }
    public string JobTypeName { get; set; }
    public string SicilNo { get; set; }
    public decimal BrutSalary { get; set; }
    public decimal NetSalary { get; set; }
    public string Iban { get; set; }
    public decimal Prim { get; set; }
    public decimal Disruptions { get; set; }
    public bool IsActive { get; set; }
    public string ManagerName { get; set; } 
    public string UserName { get; set; }
}