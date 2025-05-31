using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;

namespace Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection collection)
    {
        collection.AddDbContext<ERPDbContext>(opt =>
            opt.UseNpgsql("User ID=postgres;Password=testtest;Host=localhost;Port=5432;Database=ERPtDb;"));     
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        collection.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<ERPDbContext>()
            .AddDefaultTokenProviders(); 
        
    }
}