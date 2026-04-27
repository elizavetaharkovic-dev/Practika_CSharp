class PumpController
{
    public void OffOnPump(int waterLevel)
    {
        if (waterLevel > 80) Console.WriteLine("Насос ВКЛЮЧЕН");
        else Console.WriteLine("Насос ВЫКЛЮЧЕН");
    }
}