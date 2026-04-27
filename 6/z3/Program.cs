// Контроль над уровнем воды в резервуаре
class Program
{
    static void Main()
    {
        WaterTankSensor sensor = new WaterTankSensor();
        PumpController pump = new PumpController();
        WarningSystem warning = new WarningSystem();

        sensor.WaterLevelChanged += pump.OffOnPump;
        sensor.WaterLevelChanged += warning.Warning;

        Console.WriteLine("Уровень 50");
        sensor.SetWaterLevel(50);
        Console.WriteLine("\nУровень 75");
        sensor.SetWaterLevel(75);
        Console.WriteLine("\nУровень 85");
        sensor.SetWaterLevel(85);
        Console.WriteLine("\nУровень 95");
        sensor.SetWaterLevel(95);
    }
}