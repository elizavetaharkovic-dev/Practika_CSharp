// Даны два целых числа A и B (A < B). Найти сумму квадратов всех
// целых чисел от A до B включительно.
// Входные данные: ввести два целых числа A, B (1 <= A,B <= 10).
// Выходные данные: вывести сумму квадратов всех целых чисел от A
// до B включительно.

Console.Write("Введите А: ");
int A = int.Parse(Console.ReadLine());
Console.Write("Ввелите В: ");
int B = int.Parse(Console.ReadLine());
if (A < 1 && A > B && B > 10) Console.WriteLine("Не соответствует условию");
int sum = 0;
int i = A;
while (i <= B)
{
    sum += i * i;
    i++;
}
Console.WriteLine($"Сумма квадратов всех целых чисел от {A} до {B} = {sum}");
