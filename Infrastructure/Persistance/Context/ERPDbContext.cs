using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context;

public class ERPDbContext: IdentityDbContext<AppUser, AppRole, string>
{
    public ERPDbContext(DbContextOptions<ERPDbContext> options) : base(options) { }

    public DbSet<Departman> Departmans { get; set; }
    public DbSet<JobType> JobTypes { get; set; }    
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>()
            .HasOne(x => x.Manager)
            .WithMany()
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}