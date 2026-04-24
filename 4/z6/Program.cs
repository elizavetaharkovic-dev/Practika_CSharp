// Описать процедуру NextWeekday(D, M, Y), которая определяет
// следующий рабочий день после даты, которая включает день D, номер месяца
// M и год Y (параметры целого типа D, M, Y являются одновременно
// входными и выходными). Применить процедуру NextWeekday к трем
// исходным датам и вывести полученные значения.
class Program
{
    static void Main()
    {
        int D1 = 22, M1 = 10, Y1 = 2020;
        int D2 = 5, M2 = 3, Y2 = 2027;
        int D3 = 17, M3 = 12, Y3 = 2029;
        Console.WriteLine($"Заданный день1: {D1}.{M1}.{Y1}");
        WeekdayHelper.NextWeekday(ref D1, ref M1, ref Y1);
        Console.WriteLine($"Следующий рабочий день: {D1}.{M1}.{Y1}\n");

        Console.WriteLine($"Заданный день2: {D2}.{M2}.{Y2}");
        WeekdayHelper.NextWeekday(ref D2, ref M2, ref Y2);
        Console.WriteLine($"Следующий рабочий день: {D2}.{M2}.{Y2}\n");

        Console.WriteLine($"Заданный день3: {D3}.{M3}.{Y3}");
        WeekdayHelper.NextWeekday(ref D3, ref M3, ref Y3);
        Console.WriteLine($"Следующий рабочий день: {D3}.{ M3}.{ Y3}");
    }
}