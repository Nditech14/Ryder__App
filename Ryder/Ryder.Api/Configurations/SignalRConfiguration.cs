using Ryder.Application.Hubs;

namespace Ryder.Api.Configurations
{
	public static class SignalRConfiguration
	{
		public static void ConfigureSignalR( this IServiceCollection services, IApplicationBuilder app)
		{
			services.AddSignalR();

			app.UseEndpoints(enpoints =>
			{
				enpoints.MapHub<OrderStatusHub>("/orderStatus");
				enpoints.MapControllers();

			});

		}
	}
}
