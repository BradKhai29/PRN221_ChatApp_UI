using ChatApp_UI.Models.WebApiPayloads.Base;

namespace ChatApp_UI.Models.WebApiPayloads.Implementation.AuthWebApis.RequestBody;

public class LoginRequestBody : BaseRequestPayload
{
    public string Username { get; set; }

    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
