using ChatApp_UI.Models.Options;
using ChatApp_UI.Models.Options.Base;
using Microsoft.Extensions.Options;

namespace ChatApp_UI.OptionsSetup.Base
{
    public abstract class BaseEndpointOptionsSetup<TEndpointOptions>
        : IConfigureOptions<TEndpointOptions>
        where TEndpointOptions : BaseEndpointOptions
    {
        protected readonly IConfiguration _configuration;
        private readonly ServerUrlOptions _serverUrloptions;

        protected BaseEndpointOptionsSetup(
            IConfiguration configuration,
            ServerUrlOptions serverUrloptions)
        {
            _configuration = configuration;
            _serverUrloptions = serverUrloptions;
        }

        public abstract void Configure(TEndpointOptions options);

        protected string GetBase(TEndpointOptions options)
        {
            if (_serverUrloptions.IsRemote)
            {
                return $"{_serverUrloptions.RemoteUrl}{options.Base}";
            }

            return $"{_serverUrloptions.LocalUrl}{options.Base}";
        }
    }
}
