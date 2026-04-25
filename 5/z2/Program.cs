// Туристическое агентство и его путешествия
class Program
{
    static void Main()
    {
        Guide[] guides1 = new Guide[]
        {
            new Guide("Анна"),
            new Guide("Пётр")
        };
        Guide[] guides2 = new Guide[]
        {
            new Guide("Мария")
        };
        Guide[] guides3 = new Guide[]
        {
            new Guide("Дмиртий"),
            new Guide("Елена"),
            new Guide("Ольга")
        };

        Customer customer1 = new Customer("Максим");
        Customer customer2 = new Customer("Дарья");

        TravelAgency agency1 = new TravelAgency(guides1, "Париж");
        TravelAgency agency2 = new TravelAgency(guides2, "Гродно");
        TravelAgency agency3 = new TravelAgency(guides3, "Мосты");

        TravelAgency[] agencies = new TravelAgency[] { agency1, agency2, agency3 };

        Console.WriteLine("Все туристические агентства\n");

        foreach (TravelAgency agency in agencies)
        {
            agency.BookTour(customer1);
            agency.BookTour(customer2);
            Console.WriteLine();
        }
    }
}