class TravelAgency
{
    private Guide[] guides;
    private TourPackage tour;
    public TravelAgency(Guide[] guide, string city)
    {
        guides = guide;
        tour = new TourPackage(city);
    }
    public void BookTour(Customer customer)
    {
        string guideName = guides.Length > 0 ? guides[0].Name : "не назначен";
        Console.WriteLine($"{customer.Name} забронировал тур: {tour.Destination}\nГид: {guideName}");
    }
}