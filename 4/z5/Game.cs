abstract class Game
{
    public abstract void Play();
    public virtual void DisplayRules()
    {
        Console.WriteLine("Общие правила игры");
    }

}