using Domain.Enums;

namespace Application.Features.Results.LeaveQuotaResults;

public class GetLeaveQuotaQueryResult
{
    public string Id { get; set; }
    public string EmployeeId { get; set; } 
    public int Year { get; set; }          
    public int AllowedDays { get; set; }   
    public int UsedDays { get; set; }
    public RequestType RequestType { get; set; }    
}