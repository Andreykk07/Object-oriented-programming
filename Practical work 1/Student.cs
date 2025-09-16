using System;

namespace StudentApp
{
    class Student
    {
        private string name;
        private int age;
        private int course;
        private double rating;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value > 0 ? value : 0; }
        }

        public int Course
        {
            get { return course; }
            set { course = value > 0 ? value : 1; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = (value >= 0 && value <= 100) ? value : 0; }
        }

        public Student(string name, int age, int course, double rating)
        {
            this.Name = name;
            this.Age = age;
            this.Course = course;
            this.Rating = rating;
        }

        public void EditStudent(string newName, int newAge, double newRating)
        {
            Name = newName;
            Age = newAge;
            Rating = newRating;
        }

        public void StudentRating(double rating)
        {
            Console.WriteLine($"Рейтинг студента {Name}: {rating}");
        }

        public string GetRole(int course)
        {
            if (course >= 1 && course <= 4)
                return "Бакалавр";
            else if (course >= 5 && course <= 6)
                return "Магістр";
            else
                return "Невідомий курс";
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Ім’я: {Name}, Вік: {Age}, Курс: {Course}, Рейтинг: {Rating}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Олександр", 21, 2, 65.5);

            Console.WriteLine("Початкові дані:");
            student.PrintInfo();

            student.EditStudent("Андрій", 20, 98.3);
            Console.WriteLine("\nПісля редагування:");
            student.PrintInfo();

            student.StudentRating(student.Rating);

            Console.WriteLine($"Роль: {student.GetRole(student.Course)}");

            Console.ReadKey();
        }
    }
}
