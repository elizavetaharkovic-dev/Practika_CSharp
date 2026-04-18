// Дано трёхзначное число. Найти произведение его второй и последней цифр.

Console.Write("Введите трехзначное число:  ");
int num = int.Parse(Console.ReadLine());
int mult = ((num / 10) % 10) * (num % 10);
Console.WriteLine($"Произведение второй и последней цифр числа {num} равно {mult}.");
