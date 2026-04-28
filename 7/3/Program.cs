// Проверка корректности номера телефона
class Program
{
    static void Main()
    {
        PhoneNumberValidator validator = new PhoneNumberValidator();
        try
        {
            validator.ValidatePhoneNumber("92671090k4");
        }
        catch (InvalidPhoneNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}