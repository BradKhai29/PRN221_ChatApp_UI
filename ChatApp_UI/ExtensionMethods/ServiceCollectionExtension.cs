using ChatApp_UI.WebApis.Implementation.Auths;
using RestSharp;

namespace ChatApp_UI.ExtensionMethods;

public static class ServiceCollectionExtension
{
    /// <summary>
    ///     The required services to run this UI-application.
    /// </summary>
    public static IServiceCollection AddRequiredServices(this IServiceCollection services)
    {
        services.AddWebApiObjects();

        return services;
    }

    private static IServiceCollection AddWebApiObjects(this IServiceCollection services)
    {
        services.AddScoped<IRestClient, RestClient>();
        services.AddScoped<LoginWebApi>();

        return services;
    }
}
