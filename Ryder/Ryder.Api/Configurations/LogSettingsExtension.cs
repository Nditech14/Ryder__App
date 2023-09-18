using Raven.Client.Documents;
using Serilog;
using Serilog.Events;
using StackExchange.Redis;
using System.Security.Cryptography.X509Certificates;
using Serilog.Sinks.Redis;
using ILogger = Serilog.ILogger;

namespace Ryder.Api.Configurations
{
    public static class LogSettingsExtension
    {
        public static void SetupSeriLog(this IServiceCollection services, IConfiguration config)
        {
            var logurl = "localhost:6379";

            var redisConfigurationOptions = new RedisConfiguration()
            {
                Host = "127.0.0.1:6379", // Redis server address
                Key = "Ryder", // If Redis server requires authentication
            };
            // Create a Redis connection multiplexer
            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConfigurationOptions);

            // Create a Serilog logger configuration
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Redis(redisConfigurationOptions) // Specify the Redis connection and log key
                .CreateLogger();
            Log.Logger.Information("loggs");

            //DocumentStore ravenStore = new()
            //{
            //    Urls = new string[] { config["RavenDBConfigurations:ConnectionURL"] },
            //    Database = config["RavenDBConfigurations:DatabaseName"],
            //    Certificate = new X509Certificate2(config["RavenDBConfigurations:CertificateFilePath"],
            //        config["RavenDBConfigurations:Password"], X509KeyStorageFlags.MachineKeySet)
            //};

            //ravenStore.Initialize();
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.File(
            //        path: ".\\Logs\\log-.txt",
            //        outputTemplate:
            //        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
            //        rollingInterval: RollingInterval.Day,
            //        restrictedToMinimumLevel: LogEventLevel.Information
            //    )
            //    .CreateLogger();

            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.RavenDB(ravenStore)
            //    .CreateLogger();
        }
    }
}