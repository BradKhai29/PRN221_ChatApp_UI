using ChatApp_UI.Models.WebApiPayloads.Base;

namespace ChatApp_UI.WebApis.Base
{
    public interface IWebApi<TRequestBody, TResponseBody>
        where TRequestBody : BaseRequestPayload
        where TResponseBody : BaseResponsePayload
    {
        Task<TResponseBody> SendRequestAsync(TRequestBody body);
    }
}
