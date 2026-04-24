// Напишите метод, который вычисляет количество вхождений элемента в массиве с использованием рекурсии.
class Program
{
    static void Main()
    {
        Recursion recursion = new Recursion();
        int replay = recursion.CountOccurrences([1, 2, 3, 2, 4, 2, 2], 2);
        Console.WriteLine("Повторений: " + replay);
    }
}
