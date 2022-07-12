using Microsoft.Extensions.DependencyInjection;
using ThalesEmployees.Core.Domain.Contracts;
using ThalesEmployees.Infrastructure.DataAccess;

namespace ThalesEmployees.Infrastructure
{
    public static class Startup
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddTransient<IReadRepositoryEmployee, ReadRepositoryEmployee>();
        }
    }
}