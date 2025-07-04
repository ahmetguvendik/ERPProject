namespace Application.Features.Results.AppUserResults;

public class LoginUserQueryResult
{
    public string? Id { get; set; }
    public string? TcNo { get; set; }
    public List<string>? RoleNames { get; set; } // String yerine enum da olabilir
    public string? ManagerId { get; set; }
    public string? DepartmanId { get; set; }
}