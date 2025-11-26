using System;

class Program
{
    // Делегат для функції
    delegate double Function(double x);

    // Реалізація функцій
    static double PositiveFunc(double x)
    {
        return 1 / x;
    }

    static double NegativeFunc(double x)
    {
        return x * x + 2 * x + 4;
    }

    static double ZeroFunc(double x)
    {
        return 4;
    }

    static void Main()
    {
        Console.Write("Введіть значення x: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Потрібно було ввести число");
            return;
        }

        if (!double.TryParse(input, out double x))
        {
            Console.WriteLine("Некоректне введення");
            return;
        }

        Function func; // делегат

        if (x > 0)
            func = PositiveFunc;
        else if (x < 0)
            func = NegativeFunc;
        else
            func = ZeroFunc;

        double result = func(x);
        Console.WriteLine($"F({x}) = {result}");
    }
} 
