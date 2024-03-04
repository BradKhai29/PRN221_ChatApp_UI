namespace ChatApp_UI.Models.Options.Base
{
    public abstract class BaseEndpointOptions
    {
        public const string ParentSectionName = "WebApiEndpoints";

        /// <summary>
        ///     The base url of this endpoint.
        /// </summary>
        public string Base { get; set; }
    }
}
