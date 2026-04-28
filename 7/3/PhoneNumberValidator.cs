using System.Data;

class PhoneNumberValidator
{
    public void ValidatePhoneNumber(string phone)
    {
        if (phone.Length != 10)
        {
            throw new InvalidPhoneNumberException("Номер должен содержать 10 цифр");
        }
        for (int i = 0; i < phone.Length; i++)
        {
            if (phone[i] < '0' || phone[i] > '9')
            {
                throw new InvalidPhoneNumberException($"Недопустимый символ: { phone[i] }");
            }
        }
        Console.WriteLine("Номер валиден");
    }
}