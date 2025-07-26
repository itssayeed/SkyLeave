using Microsoft.Extensions.DependencyInjection;
using SkyLeave.Application.Services;
using SkyLeave.Domain.Interfaces;
using SkyLeave.Infrastructure.Repositories;

namespace SkyLeave.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();
            return services;
        }
    }
}
