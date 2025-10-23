using System;

namespace PracticeWork5.Task1
{
    // Ієрархія інтерфейсів
    public interface IDocument
    {
        void Print();
    }

    public interface IFinancialDocument : IDocument
    {
        void CalculateTotal();
    }

    public interface ILogisticDocument : IDocument
    {
        void ShowDeliveryInfo();
    }

    // Клас Квитанція
    public class Kvitancia : IFinancialDocument
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public void Print()
        {
            Console.WriteLine($"Квитанція №{Number} від {Date.ToShortDateString()}");
        }

        public void CalculateTotal()
        {
            Console.WriteLine($"Сума до сплати: {Amount} грн");
        }
    }

    // Клас Накладна
    public class Nakladna : ILogisticDocument
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string DeliveryAddress { get; set; }

        public void Print()
        {
            Console.WriteLine($"Накладна №{Number} від {Date.ToShortDateString()}");
        }

        public void ShowDeliveryInfo()
        {
            Console.WriteLine($"Адреса доставки: {DeliveryAddress}");
        }
    }

    // Точка входу
    class Program
    {
        static void Main(string[] args)
        {
            Kvitancia kvit = new Kvitancia
            {
                Number = "KV-001",
                Date = DateTime.Now,
                Amount = 1500.00m
            };

            Nakladna nakl = new Nakladna
            {
                Number = "NK-002",
                Date = DateTime.Now,
                DeliveryAddress = "м. Київ, вул. Хрещатик, 10"
            };

            Console.WriteLine("=== Квитанція ===");
            kvit.Print();
            kvit.CalculateTotal();

            Console.WriteLine("\n=== Накладна ===");
            nakl.Print();
            nakl.ShowDeliveryInfo();
        }
    }
}
