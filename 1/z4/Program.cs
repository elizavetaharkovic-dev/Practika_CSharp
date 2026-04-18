// Написать программу, которая вычисляет значение функции у:
//     ⎧ ln x + cos²(x²), при 1 ≤ x ≤ 5
// y = ⎨
//     ⎩ sin² x, при x = π

Console.WriteLine("Введите х");
double x = double.Parse(Console.ReadLine());
double y;
if (x >= 1 && x <= 5)
{
    y = Math.Log(x) + Math.Pow(Math.Cos(x * x), 2);
    Console.WriteLine($"{y:F3}");
}
else if (x == Math.PI)
{
    y = Math.Pow(Math.Sin(x), 2);
    Console.WriteLine($"{y:F3}");
}
else Console.WriteLine("Нет решений.");
