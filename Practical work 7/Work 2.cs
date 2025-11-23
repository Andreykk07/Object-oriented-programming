using System;
using System.Collections.Generic;

namespace Lecture8.Example2
{
    class ArrayUtilities
    {
        public static (T min, T max) FindMinMax<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Масив не може бути порожнім або null.");
            }

            T min = array[0];
            T max = array[0];

            for (int i = 1; i < array.Length; i++)
            {

                if (array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }

                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }

            return (min, max);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 5, 2, 8, 1, 9, 4 };
            var intResult = ArrayUtilities.FindMinMax(intArray);
            Console.WriteLine("--- Масив цілих чисел (int) ---");
            Console.WriteLine($"Масив: [{string.Join(", ", intArray)}]");
            Console.WriteLine($"Мінімум: {intResult.min}, Максимум: {intResult.max}"); 

            Console.WriteLine();

            double[] doubleArray = { 3.14, 1.01, 7.89, 0.55, 10.2 };
            var doubleResult = ArrayUtilities.FindMinMax(doubleArray);
            Console.WriteLine("--- Масив дійсних чисел (double) ---");
            Console.WriteLine($"Масив: [{string.Join(", ", doubleArray)}]");
            Console.WriteLine($"Мінімум: {doubleResult.min}, Максимум: {doubleResult.max}"); 

            Console.ReadKey();
        }
    }
}
