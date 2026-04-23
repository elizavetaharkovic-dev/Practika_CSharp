using System;

class Program
{
    static void Main()
    {
        SportsCompetition competition = new SportsCompetition();
        competition.Athletes = new Athlete[]
        {
            new Athlete { Name = "Усэйн Болт", Sport = "Бег", Country = "Ямайка", Records = true },
            new Athlete { Name = "Майкл Фелпс", Sport = "Плавание", Country = "США", Records = true },
            new Athlete { Name = "Новичок", Sport = "Бег", Country = "Россия", Records = false }
        };

        Console.WriteLine("Спортсмены с рекордами:");
        foreach (Athlete a in competition.GetRecordHolders())
            a.ShowInfo();

        Console.WriteLine("\nСпортсмены в беге:");
        foreach (Athlete a in competition.GetAthletesBySport("Бег"))
            a.ShowInfo();
    }
}