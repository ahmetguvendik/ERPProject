using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<string>
{
    
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public string TCNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; } 
    public DateTime StartingJob { get; set; }
    public Departman Departman { get; set; }
    public string DepartmanId { get; set; }
    public string JobTitle { get; set; }
    public JobType JobType { get; set; }
    public string JobTypeId { get; set; }
    public string SicilNo { get; set; }
    public decimal BrutSalary { get; set; }
    public decimal NetSalary { get; set; }
    public string Iban { get; set; }
    public decimal Prim { get; set; }
    public decimal Disruptions { get; set; }
    public bool IsActive { get; set; }
    public AppUser Manager { get; set; }
    public string ManagerId { get; set; }
    
    public List<LeaveQuota> LeaveQuotas { get; set; }   

    
}