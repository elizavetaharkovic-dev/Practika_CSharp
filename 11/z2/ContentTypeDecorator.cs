public class ContentTypeDecorator : HttpRequestDecorator
{
    private string _contentType;
    public ContentTypeDecorator(IHttpRequest request, string contentType) : base(request)
    {
        _contentType = contentType;
    }
    public override string GetHeaders()
    {
        return _request.GetHeaders() + $"\nContent-Type: {_contentType}";
    }
}