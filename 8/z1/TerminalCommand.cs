class TerminalCommand
{
    public string CommandText;
    public DateTime Timestamp;
    public TerminalCommand(string commandText)
    {
        CommandText = commandText;
        Timestamp = DateTime.Now;
    }
}