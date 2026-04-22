// Работа с классом StringBuilder
// Удалить все символы, кроме букв и цифр.

using System.Text;

Console.Write("Введите строку: ");
string input = Console.ReadLine();

StringBuilder result = new StringBuilder();

for (int i = 0; i < input.Length; i++)
{
    char c = input[i];
    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
    {
        result.Append(c);
    }
}

Console.WriteLine($"Результат: {result}");
