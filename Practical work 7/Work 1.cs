using System;

namespace Lecture8.Example1
{
    class Program
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            Swap<int>(ref a, ref b);
            Console.WriteLine("--- Обмін int ---");
            Console.WriteLine($"a={a} b={b}"); 

            double x = 10.5;
            double y = 20.7;
            Swap<double>(ref x, ref y);
            Console.WriteLine("\n--- Обмін double ---");
            Console.WriteLine($"x={x} y={y}"); 

            string str1 = "Hello";
            string str2 = "World";
            Swap<string>(ref str1, ref str2);
            Console.WriteLine("\n--- Обмін string ---");
            Console.WriteLine($"str1={str1} str2={str2}"); 

            Console.ReadKey();
        }
    }
}
