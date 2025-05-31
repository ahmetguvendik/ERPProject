namespace Domain.Entities;

public class Departman  : BaseEntity
{ 
    public string Name { get; set; }
    public List<AppUser> Users { get; set; }
}