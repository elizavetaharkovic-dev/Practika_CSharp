class EmailSendingException : Exception
{
    public EmailSendingException() : base() { }
    public EmailSendingException(string message) : base(message) { }
    public EmailSendingException(string message, Exception inner) : base(message, inner) { }
}