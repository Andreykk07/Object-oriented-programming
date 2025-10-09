using System;

class Tvarina
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    public Tvarina()
    {
        
    }

    public void ShowWeight()
    {
        Console.WriteLine($"Вага тварини: {Weight} кг");
    }

    public void AskWhatIsThis()
    {
        Console.WriteLine($"Ця тварина {Species} {Name}.");
    }

    public void ShowNameAndAge(string name, int age)
    {
        Console.WriteLine($"Ім’я: {name}, Вік: {age} років");
    }

    public void ShowSpeciesNameAge(string species, string name, int age)
    {
        Console.WriteLine($"Вид: {species}, Ім’я: {name}, Вік: {age} років");
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

        cat.ShowNameAndAge(cat.Name, cat.Age);
        cat.ShowSpeciesNameAge(cat.Species, cat.Name, cat.Age);

        Console.ReadKey();
    }
}
