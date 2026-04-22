//В каждой задаче задается квадратная целочисленная матрица NxN (значение
// N вводится с клавиатуры, N < 10). Программа должна заполнять матрицу
// случайными числами из диапазона [a, b] (a, b вводятся с клавиатуры) и
// осуществлять вывод на экран исходной матрицы. Затем необходимо
// произвести необходимые действия и напечатать результаты.
// Вычислить среднее арифметическое чисел, небольших заданного M.
// Вычислить сумму положительных элементов каждого столбца.
    
Console.Write("Введите размерность матрицы (NxN, N < 10): ");
int N = int.Parse(Console.ReadLine());

if (N <= 0) Console.WriteLine("Матрица должна иметь размерность!");
else if (N > 10) Console.WriteLine("Не выполняется условие N < 10");
else
{
    int[,] arr = new int [N, N];
    Console.Write($"Введите диапазон чисел в матрице [a, b]\na= ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("b= ");
    int b = int.Parse(Console.ReadLine());

    Random rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            arr[i, j] = rnd.Next(a, b);
            Console.Write(arr[i, j] + $"\t");
        }
        Console.WriteLine($"\n");
    }
    Console.WriteLine("Введите M: ");
    int M = int.Parse(Console.ReadLine());

    double sum = 0, quantity = 0;
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            if (arr[i, j] <= M)
            {
                sum += arr[i, j];
                quantity++;                 // количество таких чисел
            }
        }
    }

    double avg = sum / quantity;
    Console.WriteLine($"Среднее арифметическое чисел, небольших М={M} равно {avg:F3} \n");

    for (int j = 0; j < N; j++)
    {
        int sum1 = 0;
        for (int i = 0; i < N; i++)
        {
            if( arr[i, j] >= 0) sum1 += arr[i, j];
        }
        Console.WriteLine($"Сумма положительных элементов {j+1} столбца = {sum1}");
    }
}