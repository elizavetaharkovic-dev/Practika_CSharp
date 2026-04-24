// Методы не возвращающие значения (процедуры). Способы передачи параметров в методы.
// Описать процедуру ShiftRight3(A, B, C), выполняющую правый циклический сдвиг:
// значение A переходит в B, значение B — в C, значение C — в A (A, B, C —
// вещественные параметры, являющиеся одновременно входными и выходными). С
// помощью этой процедуры выполнить правый циклический сдвиг для двух данных
// наборов из трех чисел: (A1, B1, C1) и(A2, B2, C2).

class Program
{
    static void Main()
    {
        int A1 = 1, B1 = 2, C1 = 3, A2 = 4, B2 = 5, C2 = 6;
        Console.WriteLine($"До:\nA1={A1}, B1={B1}, C1={C1}");
        Console.WriteLine($"A2={A2}, B2={B2}, C2={C2}");
        Change change = new Change();
        change.ShiftRight3(ref A1, ref B1, ref C1);
        change.ShiftRight3(ref A2, ref B2, ref C2);
        Console.WriteLine($"\nПосле:\nA1={A1}, B1={B1}, C1={C1}");
        Console.WriteLine($"A2={A2}, B2={B2}, C2={C2}");
    }
}