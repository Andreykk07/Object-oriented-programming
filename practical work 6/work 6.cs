using System;
using System.Collections;
using System.Collections.Generic;

public class Animal : IComparable<Animal>
{
    public string Name { get; set; }
    public double Weight { get; set; } 
    public double Height { get; set; } 

    public Animal(string name, double weight, double height)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }

    public override string ToString()
    {
        return $"Тварина: {Name}, Вага: {Weight} кг, Зріст: {Height} м";
    }

    public int CompareTo(Animal other)
    {
        if (other == null) return 1;
        return this.Weight.CompareTo(other.Weight);
    }
}

public class AnimalComparerByWeightAndHeight : IComparer<Animal>
{
    public int Compare(Animal x, Animal y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        // Порівняння за вагою
        int weightComparison = x.Weight.CompareTo(y.Weight);

        if (weightComparison != 0)
        {
            return weightComparison; 
        }
        else
        {
            return x.Height.CompareTo(y.Height);
        }
    }
}


public class AnimalCollection : IEnumerable<Animal>
{
    private List<Animal> animals;

    public AnimalCollection(List<Animal> initialAnimals)
    {
        animals = initialAnimals;
    }

    public IEnumerator<Animal> GetEnumerator()
    {
        return animals.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        List<Animal> animalList = new List<Animal>
        {
            new Animal("Слон", 5000, 3.2),
            new Animal("Жираф", 1200, 5.5),
            new Animal("Лев", 190, 1.2),
            new Animal("Миша", 0.02, 0.05),
            new Animal("Кінь", 500, 1.8),
            new Animal("Носоріг", 2500, 1.7)
        };
        

        Console.WriteLine("## 1. Список тварин, впорядкований за вагою (використовуючи IComparable<Animal>):");
        Console.WriteLine("   (Використовується AnimalCollection, що реалізує IEnumerable, для ітерації)");
        Console.WriteLine("----------------------------------------------------------------------------------");

        AnimalCollection animals = new AnimalCollection(animalList);

        animalList.Sort(); 
        
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
        
        Console.WriteLine("----------------------------------------------------------------------------------");


        Console.WriteLine("\n## 2. Список тварин, впорядкований за вагою, а потім за зростом (використовуючи IComparer<Animal>):");
        Console.WriteLine("----------------------------------------------------------------------------------");
        
        List<Animal> animalListForComparer = new List<Animal>
        {
            new Animal("Ведмідь", 400, 2.0),
            new Animal("Коза", 50, 0.8),
            new Animal("Собака (Малий)", 15, 0.5),
            new Animal("Собака (Великий)", 50, 0.7), 
            new Animal("Панда", 100, 1.5),
        };
        
        animalListForComparer.Sort(new AnimalComparerByWeightAndHeight());
        
        foreach (var animal in animalListForComparer)
        {
            Console.WriteLine(animal);
        }
        
        Console.WriteLine("----------------------------------------------------------------------------------");
    }
}
