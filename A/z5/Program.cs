// Дано четырехзначное число. Найти число, образуемое
// при перестановке двух первых и двух последних цифр заданного числа.

Console.Write("Введите четырехзначное число: ");
char[] number = Console.ReadLine().ToCharArray();
(number[0], number[1], number[2], number[3]) = (number[1],  number[0], number[3], number[2]);
string result = new string(number);
Console.Write($"При перестановке цифр в вашем числе получилось число {result}");