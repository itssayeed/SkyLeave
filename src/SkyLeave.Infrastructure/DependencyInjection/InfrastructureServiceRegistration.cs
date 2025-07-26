using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkyLeave.Infrastructure.Persistence;

using SkyLeave.Infrastructure.Repositories;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddDbContext<SkyLeaveDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SkyLeaveDbConnection")));

        return services;
    }
}
