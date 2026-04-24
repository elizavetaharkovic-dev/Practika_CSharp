// Создайте расширяющий метод для типа int, который возвращает факториал числа.
class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int num = int.Parse(Console.ReadLine());
        long fact = num.Factorial();
        Console.WriteLine("Его факториал: " + fact);
    }
}