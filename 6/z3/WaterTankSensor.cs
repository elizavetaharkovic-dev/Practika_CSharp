public delegate void WLCHandler(int level);
class WaterTankSensor
{
    public int waterLevel; 
    public event WLCHandler WaterLevelChanged;
    public void SetWaterLevel(int waterLevelNew)
    {
        waterLevel = waterLevelNew;
        Console.WriteLine($"Уровень воды: {waterLevel}");
        WaterLevelChanged(waterLevel);
    }
}