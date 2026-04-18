// Написать программу, которая определяет: какая из цифр трехзначного числа больше: первая или последняя.

Console.WriteLine("Введите трехзначное число: ");
int num = int.Parse(Console.ReadLine());
if (num / 100 > num % 10) Console.WriteLine("ПЕРВАЯ цифра данного числа больше");
else if (num % 10 > num / 100) Console.WriteLine("ПОСЛЕДНЯЯ цифра данного числа больше");
else Console.WriteLine("Первая и последняя цифры данного числа РАВНЫ");