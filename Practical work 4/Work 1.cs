using System;
using System.Linq; 


public class Student
{
    public string Name { get; set; }
    
    public StudentAssesment strating1;
    public StudentAssesment strating2;


    private static Random rand = new Random();


    public class StudentAssesment
    {
        private int[] grades = new int[10];


        public void StRating()
        {
            for (int i = 0; i < grades.Length; i++)
            {

                grades[i] = rand.Next(56, 101);
            }
        }

        public double CalculateAverage()
        {
            return grades.Average();
        }

        public void PrintGrades()
        {
            Console.WriteLine(string.Join(", ", grades));
        }
    }


    public Student(string name)
    {
        Name = name;

        strating1 = new StudentAssesment();
        strating2 = new StudentAssesment();

        strating1.StRating();
        strating2.StRating();
    }


    public void MyRating()
    {
        Console.WriteLine($"РЕЗУЛЬТАТИ ДЛЯ СТУДЕНТА: {Name}");
        Console.WriteLine(new string('-', 40));

        Console.WriteLine("Оцінки за Модуль 1:");
        strating1.PrintGrades();
        double avg1 = strating1.CalculateAverage();
        Console.WriteLine($"-> Середній рейтинг за Модуль 1: {avg1:F2}"); 
        
        Console.WriteLine(); 

        Console.WriteLine("Оцінки за Модуль 2:");
        strating2.PrintGrades();
        double avg2 = strating2.CalculateAverage();
        Console.WriteLine($"-> Середній рейтинг за Модуль 2: {avg2:F2}");

        Console.WriteLine(new string('-', 40));
        
        double semesterAvg = (avg1 + avg2) / 2.0;
        Console.ForegroundColor = ConsoleColor.Green; 
        Console.WriteLine($"СЕРЕДНІЙ РЕЙТИНГ ЗА СЕМЕСТР: {semesterAvg:F2}");
        Console.ResetColor(); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Student student1 = new Student("Петренко Василь");
        
        student1.MyRating();

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}

