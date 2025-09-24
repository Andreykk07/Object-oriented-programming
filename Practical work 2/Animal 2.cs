using System;

namespace AnimalHierarchy
{
    public abstract class Тварина
    {
        public string Імя { get; set; }
        public int Вік { get; set; }

        public Тварина(string імя, int вік)
        {
            Імя = імя;
            Вік = вік;
        }

        public abstract void Вид();
        public abstract void Звук();
    }

    public class Кішка : Тварина
    {
        public string Порода { get; set; }
        public string Хвороба { get; set; }

        public Кішка(string імя, int вік, string порода, string хвороба)
            : base(імя, вік)
        {
            Порода = порода;
            Хвороба = хвороба;
        }

        public override void Вид()
        {
            Console.WriteLine($"Це кішка на ім'я {Імя}. Порода: {Порода}.");
        }

        public override void Звук()
        {
            Console.WriteLine("Мяу-мяу!");
        }

        public void ПоказатиПородуТаІмя()
        {
            Console.WriteLine($"Ця кішка {Порода}. Її звуть {Імя}.");
        }

        public void АналізХвороби(string ступінь)
        {
            switch (ступінь.ToLower())
            {
                case "тяжка":
                    Console.WriteLine("Хвороба тяжка. Потрібна операція.");
                    break;
                case "середня":
                case "середньої тяжкості":
                    Console.WriteLine("Хвороба середня. Потрібно лікування у клініці.");
                    break;
                case "легка":
                    Console.WriteLine("Хвороба легка. Лікуйте кішку дома.");
                    break;
                default:
                    Console.WriteLine("Помилка. Введіть правильно ступінь хвороби.");
                    break;
            }
        }

        public override string ToString()
        {
            return $"Кішка: {Імя}, Вік: {Вік}, Порода: {Порода}, Хвороба: {Хвороба}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Кішка іншаКішка)
            {
                return this.Імя == іншаКішка.Імя &&
                       this.Вік == іншаКішка.Вік &&
                       this.Порода == іншаКішка.Порода &&
                       this.Хвороба == іншаКішка.Хвороба;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Імя, Вік, Порода, Хвороба);
        }
    }

    public class Собака : Тварина
    {
        public string Хвороба { get; set; }
        public string Тяжкість { get; set; }

        public Собака(string імя, int вік, string хвороба, string тяжкість)
            : base(імя, вік)
        {
            Хвороба = хвороба;
            Тяжкість = тяжкість;
        }

        public override void Вид()
        {
            Console.WriteLine($"Це собака на ім'я {Імя}.");
        }

        public override void Звук()
        {
            Console.WriteLine("Гав-гав!");
        }

        public void АналізХвороби()
        {
            switch (Тяжкість.ToLower())
            {
                case "тяжка":
                    Console.WriteLine("Хвороба тяжка. Потрібна операція.");
                    break;
                case "середня":
                case "середньої тяжкості":
                    Console.WriteLine("Хвороба середня. Потрібно лікування у клініці.");
                    break;
                case "легка":
                    Console.WriteLine("Хвороба легка. Лікуйте собаку дома.");
                    break;
                default:
                    Console.WriteLine("Помилка. Введіть правильно ступінь хвороби.");
                    break;
            }
        }

        public override string ToString()
        {
            return $"Собака: {Імя}, Вік: {Вік}, Хвороба: {Хвороба}, Тяжкість: {Тяжкість}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Собака іншаСобака)
            {
                return this.Імя == іншаСобака.Імя &&
                       this.Вік == іншаСобака.Вік &&
                       this.Хвороба == іншаСобака.Хвороба &&
                       this.Тяжкість == іншаСобака.Тяжкість;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Імя, Вік, Хвороба, Тяжкість);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Кішка к1 = new Кішка("Мурка", 3, "сіамська", "глисти");
            Кішка к2 = new Кішка("Мурка", 3, "сіамська", "глисти");

            к1.Вид();
            к1.Звук();
            к1.ПоказатиПороду;
