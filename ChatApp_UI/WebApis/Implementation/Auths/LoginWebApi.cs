using ChatApp_UI.Models.Options;
using ChatApp_UI.Models.WebApiPayloads.Implementation.AuthWebApis.RequestBody;
using ChatApp_UI.Models.WebApiPayloads.Implementation.AuthWebApis.ResponseBody;
using ChatApp_UI.WebApis.Base;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ChatApp_UI.WebApis.Implementation.Auths;

public class LoginWebApi : BaseWebApi<LoginRequestBody, LoginResponseBody>
{
    private readonly AuthEndpointOptions _authEndpoint;

    public LoginWebApi(
        IRestClient restClient,
        IOptions<AuthEndpointOptions> authEndpoint) : base(restClient)
    {
        _authEndpoint = authEndpoint.Value;
    }

    public override async Task<LoginResponseBody> SendRequestAsync(LoginRequestBody body)
    {
        var loginUrl = _authEndpoint.Login;
        var method = Method.Post;

        // Set parameters for request body.
        var request = new RestRequest(resource: loginUrl, method: method);
        request.AddBody(body);

        var response = await _restClient.ExecuteAsync<LoginResponseBody>(request);

        return response.Data;
    }
}
