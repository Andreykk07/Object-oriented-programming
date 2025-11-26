using System;

class Program
{
    // Делегат для генерації послідовності чисел
    delegate void SequenceGenerator(int n);

    // Метод для генерації перших n парних чисел
    static void GenerateEvenNumbers(int n)
    {
        Console.WriteLine($"Перші {n} парних чисел:");
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"{2 * i} ");
        }
        Console.WriteLine();
    }

    // Метод для генерації перших n чисел Фібоначчі
    static void GenerateFibonacci(int n)
    {
        Console.WriteLine($"Перші {n} чисел Фібоначчі:");
        int f1 = 1, f2 = 1;

        if (n >= 1) Console.Write($"{f1} ");
        if (n >= 2) Console.Write($"{f2} ");

        for (int k = 3; k <= n; k++)
        {
            int fk = f1 + f2;
            Console.Write($"{fk} ");
            f1 = f2;
            f2 = fk;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Оберіть режим:");
        Console.WriteLine("1 - Парні числа");
        Console.WriteLine("2 - Числа Фібоначчі");
        Console.Write("Ваш вибір: ");
        string choice = Console.ReadLine();

        Console.Write("Введіть кількість чисел n: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Потрібно було ввести додатне число!");
            return;
        }

        SequenceGenerator generator;

        if (choice == "1")
        {
            generator = GenerateEvenNumbers;
        }
        else if (choice == "2")
        {
            generator = GenerateFibonacci;
        }
        else
        {
            Console.WriteLine("Некоректний вибір!");
            return;
        }

        generator(n);
    }
}
