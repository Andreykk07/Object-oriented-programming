using System;

namespace AnimalHierarchy
{
    public class Тварина
    {
        public string Імя { get; set; }
        public int Вік { get; set; }

        public Тварина(string імя, int вік)
        {
            Імя = імя;
            Вік = вік;
        }

        public virtual void Вид()
        {
            Console.WriteLine($"Це тварина. Її звуть {Імя}.");
        }

        public virtual void Звук()
        {
            Console.WriteLine("Тварина видає звук.");
        }
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Кішка кішка = new Кішка("Мурка", 3, "сіамська", "глисти");
            кішка.Вид();                    
            кішка.Звук();                   
            кішка.ПоказатиПородуТаІмя();    
            кішка.АналізХвороби("тяжка");   

            Console.WriteLine();

            Собака собака = new Собака("Барон", 5, "вушна інфекція", "середня");
            собака.Вид();                   
            собака.Звук();                  
            собака.АналізХвороби();        
        }
    }
}
