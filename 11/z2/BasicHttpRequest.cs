public class BasicHttpRequest : IHttpRequest
{
    public string GetHeaders()
    {
        return "Host: example.com";
    }
}