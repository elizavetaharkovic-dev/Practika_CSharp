public class CustomHeaderDecorator : HttpRequestDecorator
{
    private string _headerName;
    private string _headerValue;
    public CustomHeaderDecorator(IHttpRequest request, string headerName, string headerValue) : base(request)
    {
        _headerName = headerName;
        _headerValue = headerValue;
    }
    public override string GetHeaders()
    {
        return _request.GetHeaders() + $"\n{_headerName}: {_headerValue}";
    }
}