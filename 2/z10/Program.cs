// Работа с регулярными выражениями (уровень 3)
// Разделить строку по предложениям.

using System.Text.RegularExpressions;

Console.Write("Введите строку: ");
string input = Console.ReadLine();

string[] sentences = Regex.Split(input, @"(?<=[.!?])\s+");

for (int i = 0; i < sentences.Length; i++)
{
    Console.WriteLine($"{i + 1}. {sentences[i]}");
}