// Работа со строками
// Сравнить две строки на равенство без учета регистра и пробелов.

Console.Write("Введите первую строку: ");
string s1 = Console.ReadLine();
Console.Write("Введите вторую строку: ");
string s2 = Console.ReadLine();

string s1_copy = s1.Replace(" ", "").ToLower();
string s2_copy = s2.Replace(" ", "").ToLower();

if (s1_copy == s2_copy) Console.WriteLine("Строки равны");
else Console.WriteLine("Строки НЕ равны");