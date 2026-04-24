class WeekdayHelper
{
    static public void NextWeekday(ref int D, ref int M, ref int Y)
    {
        DateTime date = new DateTime(Y, M, D);
        DayOfWeek dayOfWeek = date.DayOfWeek;
        int daysAdd = 0;
        switch (dayOfWeek)
        {
            case DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday or DayOfWeek.Sunday:
                {
                    daysAdd = 1;
                    break;
                }
            case DayOfWeek.Friday:
                {
                    daysAdd = 3;
                    break;
                }
            case DayOfWeek.Saturday:
                {
                    daysAdd = 2;
                    break;
                }
        }
        DateTime nextDate = date.AddDays(daysAdd);
        D = nextDate.Day;
        M = nextDate.Month;
        Y = nextDate.Year;
    }
}