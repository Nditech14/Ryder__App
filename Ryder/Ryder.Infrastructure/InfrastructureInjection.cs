using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ryder.Infrastructure.Implementation;
using Ryder.Infrastructure.Interface;

namespace Ryder.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static void InjectInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenGeneratorService, ITokenGeneratorService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}