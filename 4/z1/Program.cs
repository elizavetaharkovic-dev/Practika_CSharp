// Реализуйте статический метод, который проверяет, является ли год високосным.

class Program
{
    static void Main()
    {
        Console.Write("Год: ");
        int year = int.Parse(Console.ReadLine()); 
        bool result = DataChecker.IsLeapYear(year);
        if (result) Console.WriteLine("Високосный");
        else Console.WriteLine("Не високосный");
    }
}
