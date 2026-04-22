// Заменить четные элементы в массиве целых чисел нулями и вывести новый массив на экран.

Console.WriteLine("Введите размерность массива: ");
int n = int.Parse(Console.ReadLine());
int[] num = new int[n];
Console.WriteLine($"Введите элементы массива: ");
for (int i = 0; i < n; i++) num[i] = int.Parse(Console.ReadLine());

Console.WriteLine("Исходный массив: " + string.Join(' ', num));

    for (int i = 0; i < n; i++)
{
    if (num[i] % 2 == 0) num[i] = 0;
}

Console.WriteLine("Получившийся после замены массив: " + string.Join(' ', num));