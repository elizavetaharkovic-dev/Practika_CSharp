// Реализация собственной коллекции MyDeque<T>
class Program
{
    static void Main()
    {
        MyDeque<int> myDeque = new MyDeque<int>();
        DequeProcessor<int> processor = new DequeProcessor<int>();
        processor.items.AddFirst(3);
        processor.items.AddLast(4);
        processor.items.AddFirst(5);
        processor.items.AddLast(9);
        processor.items.AddFirst(7);
        processor.items.AddLast(1);
        processor.items.AddFirst(10);
        processor.items.AddLast(11);

        Console.WriteLine("--Моя коллекция--");
        processor.ShowInfo();

        string result = processor.FindItem(7);
        Console.WriteLine("\n" + result + "\n\nСортировка: ");

        processor.SortItems();
        processor.items.RemoveFirst();
        processor.items.RemoveLast();

        Console.WriteLine("\n--Моя коллекция--");
        processor.ShowInfo();
    }
}