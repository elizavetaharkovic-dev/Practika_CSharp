// запрашивает с клавиатуры два целых числа, и выводит на экран результат их суммы, разности и произведения:

Console.Write("а=");
int a = int.Parse(Console.ReadLine());
Console.Write("b=");
int b = int.Parse(Console.ReadLine());
Console.WriteLine($"a+b={a}+{b}={a+b}     a-b={a}-{b}={a-b}     a*b={a}*{b}={a*b}");