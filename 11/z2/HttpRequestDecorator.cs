public abstract class HttpRequestDecorator : IHttpRequest
{
    protected IHttpRequest _request;
    public HttpRequestDecorator(IHttpRequest request)
    {
        _request = request;
    }
    public abstract string GetHeaders();
}