namespace Nodus.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDocumentService, DocumentService>();
        
        return services;
    }
    
}