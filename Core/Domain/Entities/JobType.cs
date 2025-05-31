namespace Domain.Entities;

public class JobType : BaseEntity
{
    public string Name { get; set; }
    public List<AppUser> Users { get; set; }
}