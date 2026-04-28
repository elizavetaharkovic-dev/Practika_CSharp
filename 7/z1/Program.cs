// Проверка формата телефонного номера 
// ЗАДАНИЕ 1 И ЗАДАНИЕ 3 ПОВТОРЯЮТСЯ!!!
class Program
{
    static void Main()
    {
        PhoneNumberValidator validator = new PhoneNumberValidator();
        string[] phones = { "8951703957298346713", "057j340987", "6592017566" };
        foreach (string phone in phones)
        {
            try
            {
                validator.ValidatePhoneNumber($"{phone}");
            }
            catch (InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}