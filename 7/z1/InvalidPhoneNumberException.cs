class InvalidPhoneNumberException : Exception
{  
    public InvalidPhoneNumberException() : base() { }
    public InvalidPhoneNumberException(string messsege) : base(messsege) { }
    public InvalidPhoneNumberException(string messsege, Exception inner) : base(messsege, inner) { }
}