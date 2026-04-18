// Написать программу пересчета веса из фунтов в килограммы (1 российский фунт равен 409,5 г).

Console.Write("Введите вес в фунтах и нажмите Enter  ");
double weight = double.Parse(Console.ReadLine());
double result = weight * 409.5 / 1000;
Console.WriteLine($"{weight} фунт(а/ов) - это {result:F2} кг.");