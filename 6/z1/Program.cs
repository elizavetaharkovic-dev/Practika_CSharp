// Делегат для перевода валют
delegate double CurrencyConverter(double sum);
class Program
{
    static void Main()
    {
        double dollar = 34.27;
        CurrencyConverter convert = DollarToEuro.ConvertDollarToEuro;
        double euro = convert(dollar);
        Console.WriteLine($"{dollar} долларов = {euro:F2} евро");
        convert = EuroToYen.ConvertEuroToYen;
        Console.WriteLine($"{euro:F2} евро = {convert(euro):F2} иен");
    }
}