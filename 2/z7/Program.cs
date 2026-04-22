// Работа со строками
// Инвертировать порядок слов в строке.

Console.Write("Введите строку: ");
string input = Console.ReadLine();

string[] words = input.Split(' ');
    Array.Reverse(words);
    Console.WriteLine($"Результат: {string.Join(" ", words)}");