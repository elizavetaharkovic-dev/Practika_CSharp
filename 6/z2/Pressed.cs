delegate void KeyEventHandler(int code);
class Pressed
{
    public void OnKeyEnter(int c)
    {
        Console.WriteLine("Нажата клавиша Enter");
    }
    public void OnKeyEscape(int c)
    {
        Console.WriteLine("Нажата клавиша Escape");
    }
    public void HandleKeyPress(int code, KeyEventHandler pressed)
    {
        pressed(code);
    }
}