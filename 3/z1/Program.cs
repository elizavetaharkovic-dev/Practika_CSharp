// Создать класс А с целочисленными полями а и b и двумя методами
// согласно варианту. Внутри класса реализовать конструктор для
// инициализации a и b. Создать объект класса и продемонстрировать работу со
// всеми элементами класса.
// Метод вычисления значения выражения 1/a² - 1/b³
// метод возведения в куб суммы a и b

A num = new A ();

Console.Write("a= ");
num.a = int.Parse(Console.ReadLine());
Console.Write("b= ");
num.b = int.Parse(Console.ReadLine());

double resultM1 = num.Method1(num.a, num.b);
int resultM2 = num.Method2(num.a, num.b);

Console.WriteLine($"1/a^2 - 1/b^3 = {resultM1:F3}\n(a+b)^3 = {resultM2}");

public class A
{
    public int a;
    public int b;

    public double Method1(int a, int b)
    {
        return 1.0/(a*a) - 1.0/(b*b*b);
    }
    public int Method2(int a, int b)
    {
        return (a + b)*(a+b)*(a+b);
    }
}