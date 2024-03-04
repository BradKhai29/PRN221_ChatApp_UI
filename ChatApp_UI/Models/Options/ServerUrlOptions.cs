namespace ChatApp_UI.Models.Options
{
    public class ServerUrlOptions
    {
        public const string SectionName = "ServerUrls";

        public bool IsRemote { get; set; }

        public string RemoteUrl { get; set; }

        public string LocalUrl { get; set; }
    }
}
