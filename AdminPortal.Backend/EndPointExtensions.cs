using System.Reflection;

namespace AdminPortal.Backend
{
    public static class EndPointExtensions
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            var endpointTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IEndPoint).IsAssignableFrom(t));

            foreach (var type in endpointTypes)
            {
                services.AddScoped(typeof(IEndPoint), type);
            }

            return services;
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var endpoints = scopedServices.GetServices<IEndPoint>();
                foreach (var endpoint in endpoints)
                {
                    endpoint.MapEndPoint(app);
                }
            }
            return app;
        }

    }
}
