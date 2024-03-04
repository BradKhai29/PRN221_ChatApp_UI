namespace ChatApp_UI.Models.WebApiPayloads.Base;

public abstract class BaseResponsePayload
{
    public bool IsSuccess { get; set; }

    public IEnumerable<string> ErrorMessages { get; set; }
}
