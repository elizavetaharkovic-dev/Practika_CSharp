// Напишите программу расчета по двум формулам.
// z₁ = (sin(2α) + sin(5α) - sin(3α)) / (cos(α) + 1 - 2·sin²(2α))
// z₂ = tan(3α)

Console.Write("Введите значение угла альфа в градусах:  ");
double a = double.Parse(Console.ReadLine());
double z1 = (Math.Sin(2 * a) + Math.Sin(5 * a) - Math.Sin(3 * a)) / (Math.Cos(a) + 1 - 2 * Math.Pow(Math.Sin(2 * a), 2));
double z2 = Math.Tan(3 * a);
Console.WriteLine($"Расчет по этим двум формулам привел к следующим результатам: z1 {z1:F4}, z2 {z2:F4}");