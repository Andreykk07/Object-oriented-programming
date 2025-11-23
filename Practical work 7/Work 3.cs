using System;

namespace Lecture8.Example3
{
    public class Comparer<T> where T : IComparable<T>
    {
        private T initialValue;

        public Comparer(T initial)
        {
            this.initialValue = initial;
            Console.WriteLine($"Comparer створено з початковим значенням: {initial}");
        }

        public T FindSmaller(T value1, T value2)
        {
            if (value1.CompareTo(value2) < 0)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }
        
        public T FindSmallerThanInitial(T value)
        {
             if (value.CompareTo(initialValue) < 0)
            {
                return value;
            }
            else
            {
                return initialValue;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Робота з int ---");
            Comparer<int> intComparer = new Comparer<int>(10);
            int smallerInt = intComparer.FindSmaller(5, 15);
            Console.WriteLine($"Менше з 5 та 15: {smallerInt}"); 
            
            int smallerThanInitialInt = intComparer.FindSmallerThanInitial(8);
            Console.WriteLine($"Менше з 8 та початкового 10: {smallerThanInitialInt}"); 

            Console.WriteLine();

            Console.WriteLine("--- Робота з double ---");
            Comparer<double> doubleComparer = new Comparer<double>(3.14);
            double smallerDouble = doubleComparer.FindSmaller(2.71, 9.81);
            Console.WriteLine($"Менше з 2.71 та 9.81: {smallerDouble}"); 
            
            double smallerThanInitialDouble = doubleComparer.FindSmallerThanInitial(4.0);
            Console.WriteLine($"Менше з 4.0 та початкового 3.14: {smallerThanInitialDouble}"); 

            Console.ReadKey();
        }
    }
}
