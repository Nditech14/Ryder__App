using Ryder.Infrastructure.Common.Extensions;

namespace Ryder.Api.Configurations
{
    public static class PaystackConfiguration
    {
        public static void ConfigurePaystack(this IServiceCollection services, IConfiguration configuration)
        {
            var paystackSettings = new PaystackSettings();
            configuration.GetSection("Paystack").Bind(paystackSettings);

            services.AddSingleton(paystackSettings);
        }
    }
}
