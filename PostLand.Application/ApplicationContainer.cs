using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PostLand.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection 
            AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
