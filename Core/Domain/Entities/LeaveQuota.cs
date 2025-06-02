using Domain.Enums;

namespace Domain.Entities;

public class LeaveQuota : BaseEntity
{
    public string EmployeeId { get; set; } 
    public int Year { get; set; }
    public RequestType RequestType { get; set; }    
    public int AllowedDays { get; set; }   
    public int UsedDays { get; set; }     
    
    public AppUser Employee { get; set; }   
}