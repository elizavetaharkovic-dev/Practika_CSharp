// Написать программу, находящую наибольшую и наименьшую цифры заданного натурального числа.

Console.WriteLine("Введите натуральное число");
int num = int.Parse(Console.ReadLine());
if (num < 0) Console.WriteLine("Нужно натуральное число");
int min = 10, max = 0;
while (num > 0)
{
    int digit = num % 10;
    if (digit < min) min = digit;
    if (digit > max) max = digit;
    num = num / 10;
}
Console.WriteLine($"Наибольшая: {max}\nНаименьшая: {min}");
