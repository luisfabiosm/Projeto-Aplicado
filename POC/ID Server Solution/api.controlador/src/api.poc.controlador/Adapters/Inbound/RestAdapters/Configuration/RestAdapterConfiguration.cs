namespace Adapters.Inbound.RestAdapters.Configuration
{
    public static class RestAdapterConfiguration
    {
        public static IServiceCollection AddRestEndpoints(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();

            return services;
        }

        public static void UseAPIExtensions(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Development" || app.Environment.EnvironmentName == "Local" || app.Environment.EnvironmentName == "Fabrica")
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            //Endpoints
            app.AddAbrirTesourariaEndpoint();
    
        }
    }

}
}
