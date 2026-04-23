using System;
using System.Linq;

class SportsCompetition
{
    public Athlete[] Athletes { get; set; }

    public Athlete[] GetAthletesBySport(string sport)
    {
        return Athletes.Where(a => a.Sport == sport).ToArray();
    }

    public Athlete[] GetRecordHolders()
    {
        return Athletes.Where(a => a.Records == true).ToArray();
    }
}