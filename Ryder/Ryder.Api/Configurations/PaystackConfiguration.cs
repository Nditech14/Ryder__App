using Ryder.Infrastructure.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PayStack.Net;
using Ryder.Infrastructure.Common.Extensions;
using Ryder.Infrastructure.Implementation;

namespace Ryder.Api.Configurations
{
    public static class PaystackConfiguration
    {
        public static void ConfigurePaystack(this IServiceCollection services, IConfiguration configuration)
        {
            var paystackSettings = new PaystackSettings();
            configuration.GetSection("Paystack").Bind(paystackSettings);
            services.AddSingleton(paystackSettings);

            string paystackSecretKey = paystackSettings.LiveSecretKey;

            
            services.AddScoped<IPaystackService>(provider =>
            {
                var paystack = new PayStackApi(paystackSecretKey);
                return new PaystackService(paystack);
            });
        }
    }
}
