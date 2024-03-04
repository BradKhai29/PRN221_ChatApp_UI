using ChatApp_UI.Models.Options;
using ChatApp_UI.OptionsSetup;

namespace ChatApp_UI.ExtensionMethods;

public static class OptionsConfiguration
{
    /// <summary>
    ///     The required services to run this UI-application.
    /// </summary>
    public static IServiceCollection AddOptionsConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Set up the server-url options.
        services.AddSingleton(options => GetServerUrlOptions(configuration));

        // Set up other endpoint options.
        services.ConfigureOptions<AuthEndpointOptionsSetup>();

        return services;
    }

    private static ServerUrlOptions GetServerUrlOptions(IConfiguration configuration)
    {
        var options = new ServerUrlOptions();

        configuration
            .GetRequiredSection(ServerUrlOptions.SectionName)
            .Bind(options);

        return options;
    }
}
