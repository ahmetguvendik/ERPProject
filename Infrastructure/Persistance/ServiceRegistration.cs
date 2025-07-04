using Application.Repostitories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;

namespace Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection collection)
    {
        collection.AddDbContext<ERPDbContext>(opt =>
            opt.UseNpgsql("User ID=postgres;Password=testtest;Host=localhost;Port=5432;Database=ERPDb;"));     
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        collection.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<ERPDbContext>()
            .AddDefaultTokenProviders();


        collection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        collection.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        collection.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
        collection.AddScoped(typeof(ILeaveQuotaRepository), typeof(LeaveQuotaRepository));   
        collection.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));   
        collection.AddScoped(typeof(IPurchaseRepository), typeof(PurchaseRepository));      
        collection.AddScoped(typeof(IPurchaseRequestItemRepository), typeof(PurchaseRequestItemRepository));
        collection.AddScoped(typeof(IPurchaseOfferRepository), typeof(PurchaseOfferRepository));      

    }
    
    
}