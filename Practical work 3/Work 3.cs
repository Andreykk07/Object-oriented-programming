using System;

class DayCollection
{
    readonly string[] days = 
    { 
        "Понеділок"
        "Вівторок"
        "Середа" 
        "Четвер"
        "П'ятниця" 
        "Субота" 
        "Неділя" 
    };

    private int GetDay(string testDay)
    {
        for (int j = 0; j < days.Length; j++)
        {
            if (days[j] == testDay)
            {
                return j;
            }
        }

        throw new ArgumentOutOfRangeException(testDay, "неправильно вказаний день тижня");
    }

    public int this[string day] => GetDay(day);
}
class Program
{
    static void Main(string[] args)
    {
        DayCollection week = new();

        Console.WriteLine(week["Середа"]);

        try
        {
            Console.WriteLine(week["перший день"]);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
