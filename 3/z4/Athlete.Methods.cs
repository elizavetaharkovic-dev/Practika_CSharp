using System;

partial class Athlete
{
    public void ShowInfo()
    {
        Console.WriteLine($"{Name}, {Country}, {Sport}, Рекорд: {(Records ? "Да" : "Нет")}");
    }
}