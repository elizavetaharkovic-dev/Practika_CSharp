// Реализация паттерна "Декоратор". Веб-запрос – добавление HTTP-заголовков.
class Program
{
    static void Main()
    {
        IHttpRequest request = new BasicHttpRequest();

        request = new AuthHeaderDecorator(request, "abc123xyz");
        request = new ContentTypeDecorator(request, "application/json");
        request = new CustomHeaderDecorator(request, "X-Request-ID", "12345");

        Console.WriteLine(request.GetHeaders());
    }
}