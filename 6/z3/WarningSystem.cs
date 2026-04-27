class WarningSystem
{
    public void Warning(int waterLevel)
    {
        if (waterLevel > 90) Console.WriteLine("ПЕРЕПЛНЕНИЕ! Опасно!");
        else if (waterLevel > 70 && waterLevel < 90) Console.WriteLine("Предупреждение: высокий уровень");
    }
}