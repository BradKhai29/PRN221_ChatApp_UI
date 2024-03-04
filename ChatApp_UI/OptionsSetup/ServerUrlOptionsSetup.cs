using ChatApp_UI.Models.Options;
using Microsoft.Extensions.Options;

namespace ChatApp_UI.OptionsSetup
{
    public class ServerUrlOptionsSetup : IConfigureOptions<ServerUrlOptions>
    {
        private readonly IConfiguration _configuration;

        public ServerUrlOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(ServerUrlOptions options)
        {
            _configuration
                .GetRequiredSection(key: ServerUrlOptions.SectionName)
                .Bind(instance: options);
        }
    }
}
