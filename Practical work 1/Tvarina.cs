using System;

class Tvarina
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    public Tvarina()
    {
        //значення встановлюються через властивості
    }

    public void ShowWeight()
    {
        Console.WriteLine($"Вага тварини: {Weight} кг");
    }

    public void AskWhatIsThis()
    {
        Console.WriteLine($"Ця тварина {Species} {Name}.");
    }
}
class Program
{
    static void Main()
    {
        Tvarina cat = new Tvarina();

        cat.Name = "Мурка";
        cat.Species = "кішка";
        cat.Age = 3;
        cat.Weight = 4.2;

        cat.ShowWeight();
        cat.AskWhatIsThis();

        Console.ReadKey();
    }
}
