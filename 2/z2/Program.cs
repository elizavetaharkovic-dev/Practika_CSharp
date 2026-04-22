// Во всех задачах сформировать и вывести на экран одномерный массив
// согласно варианту. Произвести его сортировку и бинарный поиск числа k (k -
// вводится с клавиатуры). Напишите программу для решения задачи:
// Пусть даны целые числа а1, ..., ап. Если в данной последовательности
// ни одно четное число не расположено после нечетного, то напечатайте все
// отрицательные члены последовательности, иначе - все положительные.
// Порядок следования чисел в обоих случаях замените обратным.

Console.WriteLine("Введите размерность массива: ");
int n = int.Parse(Console.ReadLine());
int[] num = new int[n];

Random rnd = new Random();
for (int i = 0; i < n; i++) num[i] = rnd.Next(-99, 100);

Console.WriteLine("Исходный массив: " + string.Join(" ", num));

bool foundOdd = false;      // было ли нечётное число?
bool condition = true;      // выполнено ли условие?

for (int i = 0; i < n; i++)
{
    if (num[i] % 2 != 0)
        foundOdd = true;
    else if (foundOdd)  
    {
        condition = false;
        break;
    }
}

int[] result;

if (condition)
{
    // берём отрицательные
    result = new int[n];
    int count = 0;
    for (int i = 0; i < n; i++)
        if (num[i] < 0) result[count++] = num[i];
    Array.Resize(ref result, count);
}
else
{
    // берём положительные
    result = new int[n];
    int count = 0;
    for (int i = 0; i < n; i++)
        if (num[i] > 0) result[count++] = num[i];
    Array.Resize(ref result, count);
}

Array.Reverse(result);

Console.WriteLine("Результат: " + string.Join(" ", result));

Array.Sort(num);
Console.WriteLine("Отсортированный массив: " + string.Join(' ', num));

Console.Write("Введите число которое нужно найти: ");
int k = int.Parse(Console.ReadLine());

int id = Array.BinarySearch(num, k);
if (id > 0) Console.WriteLine($"Заданное число {k} находится в массиве на {id} позиции");
else Console.WriteLine("В этом массиве такого числа нету");
