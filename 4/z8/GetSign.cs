class GetSign
{
    static public void DetermineSign(in double number, out string result)
    {
        if (number < 0) result = "Отрицательное";
        else if (number > 0) result = "Положительное";
        else result = "Ноль";
    }
    static public void DetermineSign(in int number, out string result)
    {
        if (number < 0) result = "Отрицательное";
        else if (number > 0) result = "Положительное";
        else result = "Ноль";
    }
}