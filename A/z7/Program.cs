// Найти: площадь трапеции S, если заданы стороны

Console.Write("Введите длину основания трапеции а= ");
int a = int.Parse(Console.ReadLine());
Console.Write("Введите длину основания b= ");
int b = int.Parse(Console.ReadLine());
Console.Write("Введите высоту трапеции h= ");
int h = int.Parse(Console.ReadLine());
int S = ((a + b) / 2) * h;
Console.WriteLine("Площадь трапеции: " + S);