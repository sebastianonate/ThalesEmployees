using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ThalesEmployees.Core.Domain.Contracts;


namespace ThalesEmployees.Core.Application
{
    public static class Startup 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }       
    }
}