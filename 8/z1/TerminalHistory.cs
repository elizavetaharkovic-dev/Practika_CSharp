using System.Collections;
class TerminalHistory
{
    public Stack commands;
    public TerminalHistory()
    {
        commands = new Stack();
    }
    public void AddCommand(string text)
    {
        TerminalCommand cmd = new TerminalCommand(text);
        commands.Push(cmd);
    }
    public void RemoveCommand()
    {
        commands.Pop();
    }
    public TerminalCommand FindCommand(string text)
    {
        foreach (TerminalCommand cmd in commands)
        {
            if (cmd.CommandText == text) { return cmd; }
        }
        return null;
}
    public void ClearHistory()
    {
        commands.Clear();
    }
    public void ShowHistory()
    {
        foreach (TerminalCommand cmd in commands) Console.WriteLine($"{cmd.Timestamp} - {cmd.CommandText}");
    }
}