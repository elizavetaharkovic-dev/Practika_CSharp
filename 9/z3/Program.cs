// Определение самой прибыльной сделки
class Program
{
    static void Main()
    {
        string list = "[{ \"Id\":1, \"Revenue\":1500.25 },{ \"Id\":2, \"Revenue\":1300.00 },{ \"Id\":3, \"Revenue\":2890.50 },{ \"Id\":4, \"Revenue\":4500.75 },{ \"Id\":5, \"Revenue\":3200.00 },{ \"Id\":6, \"Revenue\":980.50 },{ \"Id\":7, \"Revenue\":2100.00 },{ \"Id\":8, \"Revenue\":5600.25 },{ \"Id\":9, \"Revenue\":1750.75 },{ \"Id\":10, \"Revenue\":4300.00 }]";
        File.WriteAllText("file.data", list);
        DealFileReader readFile = new DealFileReader();
        List<Deal> deals = readFile.ReadDeals();
        DealProcessor processor = new DealProcessor();
        Deal deal = processor.FindMostProfitableDeal(deals);
        Console.WriteLine("Самая выгодная сделка: " + deal.ToString());

        Console.Write("\nВведите id искомой сделки: ");
        int id = int.Parse(Console.ReadLine());
        Deal deal1 = processor.FindDealById(deals, id);
        Console.WriteLine("Поиск: Искомая сделка: " + deal1.ToString());

        Console.Write("\nВведите минимальное значение для фильтрации (все сделки с прибылью больше заданной): ");
        float minRevenue = float.Parse(Console.ReadLine());
        List<Deal> dealsList = processor.FilterByRevenue(deals, minRevenue);
        Console.WriteLine($"Фильтация: Все сделки с прибылью больше {minRevenue}:");
        foreach (Deal d in dealsList)
        {
            Console.WriteLine(d.ToString());
        }

        Console.WriteLine("\nСортировка: Отсортированный список сделок: ");
        processor.SortByRevenueDesc(deals);
        foreach (Deal d in deals)
        {
            Console.WriteLine(d.ToString());
        }
    }
}