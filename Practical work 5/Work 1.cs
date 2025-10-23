using System;

namespace TvarynyApp
{
    // Інтерфейс IZvir
    public interface IZvir
    {
        string Name { get; set; }
        int Age { get; set; }

        void Golos();
        void Poroda();
    }

    // Базовий клас Tvarina
    public abstract class Tvarina : IZvir
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public abstract void Golos();
        public abstract void Poroda();
    }

    // Клас Kishka
    public class Kishka : Tvarina
    {
        public override void Golos()
        {
            Console.WriteLine("Кішка каже: Мяу!");
        }

        public override void Poroda()
        {
            Console.WriteLine("Порода кішки: Сіамська");
        }
    }

    // Клас Sobaka
    public class Sobaka : Tvarina
    {
        public override void Golos()
        {
            Console.WriteLine("Собака каже: Гав!");
        }

        public override void Poroda()
        {
            Console.WriteLine("Порода собаки: Лабрадор");
        }
    }

    // Точка входу
    class Program
    {
        static void Main(string[] args)
        {
            IZvir myCat = new Kishka { Name = "Мурка", Age = 3 };
            IZvir myDog = new Sobaka { Name = "Барон", Age = 5 };

            Console.WriteLine($"Кішка: {myCat.Name}, Вік: {myCat.Age}");
            myCat.Golos();
            myCat.Poroda();

            Console.WriteLine($"\nСобака: {myDog.Name}, Вік: {myDog.Age}");
            myDog.Golos();
            myDog.Poroda();
        }
    }
}
