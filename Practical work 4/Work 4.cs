using System;

static class ArraySearch
{
    public static void FindMinMax(int[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("Масив порожній.");
            return;
        }

        int min = array[0];
        int max = array[0];

        foreach (int num in array)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Мінімальний елемент: {min}");
    }

    public static void CountOccurrences(int[] array, int target)
    {
        int count = 0;
        foreach (int num in array)
        {
            if (num == target) count++;
        }

        Console.WriteLine($"Цифра {target} зустрічається {count} раз(и).");
    }
}

class Program
{
    static void Main()
    {
        int[] array1 = { 4, 5, 2, 3, 8, 7, 6, 1 };
        int[] array2 = { 1, 2, 5, 3, 7, 5, 1, 3, 4 };

        Console.WriteLine("Пошук мінімального і максимального:");
        ArraySearch.FindMinMax(array1);

        Console.WriteLine("\nПошук кількості входжень:");
        ArraySearch.CountOccurrences(array2, 5); 
        ArraySearch.CountOccurrences(array2, 1); 
    }
}
