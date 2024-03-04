using ChatApp_UI.Models.WebApiPayloads.Base;

namespace ChatApp_UI.Models.WebApiPayloads.Implementation.AuthWebApis.ResponseBody;

public class LoginResponseBody : BaseResponsePayload
{
    public TokenBody Body { get; set; }

    public class TokenBody
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
