public class Car
{
    public string name { get; set; }
    public bool status {  get; set; }
    public double pricePerDay { get; set; }
    public override string ToString()
    {
        string carInfo = "";
        if (status)
        {
            carInfo = $"{name} - Доступно - {pricePerDay} руб/дн";
            return carInfo;
        }
        else
        {
            carInfo = $"{name} - Арендовано - {pricePerDay} руб/дн";
            return carInfo;
        }
    }
}