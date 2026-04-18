// Вывести на экран (задачу решите тремя способами -
// используя операторы цикла while, do while и for):
// все целые числа из диапазона от А до В, кратные трем (A <= B).

int A = 5;
int B = 32;
int i = A;
int k = A;
Console.WriteLine("Используем цикл while");
while (i <= B)
{
    if (i % 3 == 0)
    {
        Console.WriteLine(i + " ");
    }
    i++;
}
Console.WriteLine("Используем цикл do while");
do
{
    if (k % 3 == 0)
    {
        Console.WriteLine(k + " ");
    }
    k++;
}  while (k <= B);
Console.WriteLine("Используем цикл for");
for (int j = A; j <= B; j++)
{
    if (j % 3 == 0)
    {
        Console.WriteLine(j + " ");
    }
}