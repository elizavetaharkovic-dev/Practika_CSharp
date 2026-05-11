public class AuthHeaderDecorator : HttpRequestDecorator
{
    private string _token;
    public AuthHeaderDecorator(IHttpRequest request, string token) : base(request)
    {
        _token = token;
    }
    public override string GetHeaders()
    {
        return _request.GetHeaders() + $"\nAuthorization: Bearer {_token}";
    }
}