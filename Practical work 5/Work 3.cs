using System;
using System.Collections.Generic;

namespace BankSystem
{
    // Інтерфейс з методами для керування рахунком
    public interface IAccountManager
    {
        void Новий_рахунок();
        void Видалити_рахунок();
    }

    // Базовий клас Банківський рахунок
    public abstract class BankAccount : IAccountManager
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; protected set; }

        public virtual void Новий_рахунок()
        {
            Console.WriteLine($"Створено новий рахунок №{AccountNumber} для {Owner}");
        }

        public virtual void Видалити_рахунок()
        {
            Console.WriteLine($"Рахунок №{AccountNumber} видалено");
        }

        public abstract void Поповнити_рахунок(decimal amount);
        public abstract void Зняти_з_рахунку(decimal amount);
    }

    // Поточний рахунок
    public class CurrentAccount : BankAccount
    {
        public override void Поповнити_рахунок(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Поточний рахунок поповнено на {amount} грн. Баланс: {Balance} грн");
        }

        public override void Зняти_з_рахунку(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Знято {amount} грн з поточного рахунку. Баланс: {Balance} грн");
            }
            else
            {
                Console.WriteLine("Недостатньо коштів на рахунку!");
            }
        }
    }

    // Депозитний рахунок
    public class DepositAccount : BankAccount
    {
        public override void Поповнити_рахунок(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Депозит поповнено на {amount} грн. Баланс: {Balance} грн");
        }

        public override void Зняти_з_рахунку(decimal amount)
        {
            Console.WriteLine("Зняття коштів з депозитного рахунку можливе лише після закінчення терміну депозиту.");
        }
    }

    // Точка входу
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();

            // Створення поточного рахунку
            CurrentAccount current = new CurrentAccount
            {
                AccountNumber = "CA-001",
                Owner = "Іван Іванов",
                Balance = 0
            };
            current.Новий_рахунок();
            current.Поповнити_рахунок(1000);
            current.Зняти_з_рахунку(300);
            accounts.Add(current);

            Console.WriteLine();

            // Створення депозитного рахунку
            DepositAccount deposit = new DepositAccount
            {
                AccountNumber = "DA-002",
                Owner = "Олена Петрівна",
                Balance = 0
            };
            deposit.Новий_рахунок();
            deposit.Поповнити_рахунок(5000);
            deposit.Зняти_з_рахунку(1000); // не дозволено
            accounts.Add(deposit);

            Console.WriteLine();

            // Видалення рахунків
            foreach (var acc in accounts)
            {
                acc.Видалити_рахунок();
            }
        }
    }
}
