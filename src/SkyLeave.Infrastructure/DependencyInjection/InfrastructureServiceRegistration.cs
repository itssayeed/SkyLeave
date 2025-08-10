using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkyLeave.Application.Interfaces;
using SkyLeave.Infrastructure.Persistence;
using SkyLeave.Infrastructure.Repositories;
using SkyLeave.Application.Services;
using SkyLeave.Domain.Interfaces;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>(); // Changed to specific implementation
        services.AddScoped<ILeaveBalanceRepository, LeaveBalanceRepository>();
        services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        services.AddScoped<IUserService, UserService>();
        services.AddDbContext<SkyLeaveDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SkyLeaveDbConnection")));
        return services;
    }
}