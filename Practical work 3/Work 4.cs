using System;

class Student
{
    private int[] grades = new int[10];  

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= grades.Length)
                throw new IndexOutOfRangeException("Індекс поза межами масиву оцінок.");
            return grades[index];
        }
        set
        {
            if (index < 0 || index >= grades.Length)
                throw new IndexOutOfRangeException("Індекс поза межами масиву оцінок.");
            if (value < 0 || value > 100) 
                throw new ArgumentOutOfRangeException("Оцінка має бути в межах від 0 до 100.");
            grades[index] = value;
        }
    }

    public double CalculateAverage()
    {
        int sum = 0;
        int count = 0;
        foreach (var grade in grades)
        {
            sum += grade;
            count++;
        }
        return count == 0 ? 0 : (double)sum / count;
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student();

        for (int i = 0; i < 10; i++)
        {
            student[i] = 60 + i * 4; 
        }

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Оцінка за дисципліну {i + 1}: {student[i]}");
        }

        double average = student.CalculateAverage();
        Console.WriteLine($"Середній рейтинг студента: {average:F2}");
    }
}
