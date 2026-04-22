// Работа со ступенчатыми массивами
// Реализовать бинарный поиск внутри ступенчатого массива.

int[][] arr = new int[3][];
arr[0] = new int[5];
arr[1] = new int[3];
arr[2] = new int[2];

Console.WriteLine("Заданный массив:");
Random rnd = new Random();
for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < arr[i].Length; j++)
    {
        arr[i][j] = rnd.Next(0,10);
        Console.Write(arr[i][j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine("");

Console.Write("Введите элемент который хотите найти: ");
int element = int.Parse(Console.ReadLine());

for (int i = 0; i < arr.Length; i++)
{
    Array.Sort(arr[i]);
    int index = Array.BinarySearch(arr[i], element);
    if (index >= 0)
    {
        Console.WriteLine($"Число найдено в строке {i + 1}");
        break;
    }
}