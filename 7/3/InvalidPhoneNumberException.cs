class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException() : base() { }
    public InvalidPhoneNumberException(string message) : base(message) { }
    public InvalidPhoneNumberException(string message, Exception inner) : base(message, inner) { }
}