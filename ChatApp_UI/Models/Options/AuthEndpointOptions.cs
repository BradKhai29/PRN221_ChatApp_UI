using ChatApp_UI.Models.Options.Base;

namespace ChatApp_UI.Models.Options
{
    public class AuthEndpointOptions : BaseEndpointOptions
    {
        public const string SectionName = "Auth";

        public string Login { get; set; }

        public string Register { get; set; }

        public string Logout { get; set; }

        public string ForgotPassword { get; set; }
    }
}
