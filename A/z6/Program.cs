// Вычислить значение функции для заданного значения аргумента:
// y = 7·arctg²(√(e^x + 1)) + |x|, при x = -1

double x = -1;
double y = 7 * Math.Pow(Math.Atan(Math.Sqrt(Math.Pow(Math.E, x) + 1)), 2) + Math.Abs(x);
Console.WriteLine("Результат  " + y);
