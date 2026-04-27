// Делегат для обработки событий клавиатуры
class Program
{
    static void Main()
    {
        Pressed pressed = new Pressed();
        pressed.HandleKeyPress(13, pressed.OnKeyEnter);
        pressed.HandleKeyPress(27, pressed.OnKeyEscape);
    }
}