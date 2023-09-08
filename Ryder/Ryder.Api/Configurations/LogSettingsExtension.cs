using Raven.Client.Documents;
using Serilog;
using Serilog.Events;
using System.Security.Cryptography.X509Certificates;
using ILogger = Serilog.ILogger;

namespace Ryder.Api.Configurations
{
    public static class LogSettingsExtension
    {
        public static void SetupSeriLog(this IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
        {
            DocumentStore ravenStore = new()
            {
                Urls = new string[] { config["RavenDBConfigurations:ConnectionURL"] },
                Database = config["RavenDBConfigurations:DatabaseName"],
                Certificate = new X509Certificate2(config["RavenDBConfigurations:CertificateFilePath"],
                    config["RavenDBConfigurations:Password"], X509KeyStorageFlags.MachineKeySet)
            };

            ravenStore.Initialize();

            if (environment.IsDevelopment())
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(
                        path: ".\\Logs\\log-.txt",
                        outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Information
                    )
                    .CreateLogger();
            }

            Log.Logger = new LoggerConfiguration()
                .WriteTo.RavenDB(ravenStore)
                .CreateLogger();
        }
    }
}