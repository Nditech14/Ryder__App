using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ryder.Infrastructure.Common.Behaviours;
using Ryder.Infrastructure.Implementation;
using Ryder.Infrastructure.Interface;

namespace Ryder.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static void InjectInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}