//Табулирование функций.
// Постановка задачи: Составить программу вычисления значений
// функции F(x) на отрезке [A, B] в точках x i =x+H, где H=(B-A)/M, M – заданное
// целое число.
// заданные параметры и функция прописаны в коде.

double A = Math.PI/6;
double B = 2 * Math.PI / 3;
double M = 10;
double H = (B - A) / M;
double x = A;

for (int i = 1; i <= M; i++)
{
    double y = Math.Sin(x * x);
    Console.WriteLine($"x = {x:F4}   y = {y:F6}");
    x = x + H;
}
