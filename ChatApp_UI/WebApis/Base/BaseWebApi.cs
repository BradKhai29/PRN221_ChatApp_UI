using ChatApp_UI.Models.WebApiPayloads.Base;
using RestSharp;

namespace ChatApp_UI.WebApis.Base;

public abstract class BaseWebApi<TRequestBody, TResponseBody>
    : IWebApi<TRequestBody, TResponseBody>
    where TRequestBody : BaseRequestPayload
    where TResponseBody : BaseResponsePayload
{
    protected readonly IRestClient _restClient;

    public BaseWebApi(IRestClient restClient)
    {
        _restClient = restClient;
    }

    public abstract Task<TResponseBody> SendRequestAsync(TRequestBody body);
}
