// Работа с символами
// Реализовать метод, убирающий повторяющиеся подряд символы в строке.

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        string output = RemoveDuplicateChars(input);

        Console.WriteLine($"Результат: {output}");
    }

    static string RemoveDuplicateChars(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        char[] result = new char[input.Length];
        result[0] = input[0];
        int count = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                result[count] = input[i];
                count++;
            }
        }

        return new string(result, 0, count);
    }
}
