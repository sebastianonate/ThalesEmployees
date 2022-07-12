using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ThalesEmployees.Core.Domain.Contracts;
using ThalesEmployees.Infrastructure.DataAccess;
using ThalesEmployees.Infrastructure.Middleware;

namespace ThalesEmployees.Infrastructure
{
    public static class Startup
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddTransient<IReadRepositoryEmployee, ReadRepositoryEmployee>()
                .AddExceptionMiddleware();
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder) =>
            builder
                .UseExceptionMiddleware();

        internal static IServiceCollection AddExceptionMiddleware(this IServiceCollection services) =>
               services.AddScoped<ExceptionMiddleware>();

        internal static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionMiddleware>();
    }
}