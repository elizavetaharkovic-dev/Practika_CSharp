namespace RentCars
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public double PricePerDay { get; set; }
        public string Class { get; set; }

        public string StatusText
        {
            get { return Status ? "Доступно" : "Арендовано"; }
        }

        public override string ToString()
        {
            string carInfo = "";
            if (Status)
            {
                carInfo = $"{Name} - Доступно - {PricePerDay} руб/дн";
                return carInfo;
            }
            else
            {
                carInfo = $"{Name} - Арендовано - {PricePerDay} руб/дн";
                return carInfo;
            }
        }
    }
}