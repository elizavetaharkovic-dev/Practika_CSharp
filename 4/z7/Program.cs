// Рассчет площади окружности
class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        double circle = calculator.CalculateCircumference(5);
        double rectangle = calculator.CalculateCircumference(4, 6);
        Console.WriteLine($"Окружность: {circle:F2}, Периметр: {rectangle}");
    }
}
