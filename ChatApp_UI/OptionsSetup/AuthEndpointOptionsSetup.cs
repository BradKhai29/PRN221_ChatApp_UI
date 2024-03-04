using ChatApp_UI.Models.Options;
using ChatApp_UI.Models.Options.Base;
using ChatApp_UI.OptionsSetup.Base;

namespace ChatApp_UI.OptionsSetup
{
    public class AuthEndpointOptionsSetup : BaseEndpointOptionsSetup<AuthEndpointOptions>
    {
        public AuthEndpointOptionsSetup(
            IConfiguration configuration,
            ServerUrlOptions serverUrloptions) 
            : base(configuration, serverUrloptions)
        {
        }

        public override void Configure(AuthEndpointOptions options)
        {
            _configuration
                .GetRequiredSection(key: BaseEndpointOptions.ParentSectionName)
                .GetRequiredSection(key: AuthEndpointOptions.SectionName)
                .Bind(instance: options);

            // Construct the endpoints.
            options.Base = GetBase(options: options);
            options.Login = $"{options.Base}{options.Login}";
            options.Register = $"{options.Base}{options.Register}";
            options.Logout = $"{options.Base}{options.Logout}";
            options.ForgotPassword = $"{options.Base}{options.ForgotPassword}";
        }
    }
}
