// Создайте метод, который определяет, положительное, отрицательное или ноль переданное значение.
// Перегрузите его.
class Program
{
    static void Main()
    {
        double num1 = -5; int num2 = 0;
        GetSign.DetermineSign(in num1, out string result1);
        Console.WriteLine($"{num1} = {result1}");
        GetSign.DetermineSign(in num2, out string result2);
        Console.WriteLine($"{num2} = {result2}");
    }
}