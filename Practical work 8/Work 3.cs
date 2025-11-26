using System;

class Program
{
    // Окремі методи для арифметичних операцій
    static double Add(double a, double b) => a + b;
    static double Sub(double a, double b) => a - b;
    static double Mul(double a, double b) => a * b;
    static double Div(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Ділення на нуль неможливе!");
            return double.NaN;
        }
        return a / b;
    }

    static void Main()
    {
        Console.WriteLine("Арифметичний калькулятор (+, -, *, /)");
        Console.Write("Введіть перше число: ");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Некоректне введення!");
            return;
        }

        Console.Write("Введіть друге число: ");
        if (!double.TryParse(Console.ReadLine(), out double y))
        {
            Console.WriteLine("Некоректне введення!");
            return;
        }

        Console.Write("Введіть операцію (+, -, *, /): ");
        string op = Console.ReadLine();

        // Використання універсального делегата Func<double,double,double>
        Func<double, double, double> operation;

        switch (op)
        {
            case "+":
                operation = Add;
                break;
            case "-":
                operation = Sub;
                break;
            case "*":
                operation = Mul;
                break;
            case "/":
                operation = Div;
                break;
            default:
                Console.WriteLine("Невідома операція!");
                return;
        }

        double result = operation(x, y);
        Console.WriteLine($"Результат: {result}");
    }
}
