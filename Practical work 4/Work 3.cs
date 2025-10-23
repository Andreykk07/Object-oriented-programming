using System;
using System.Text;

public class Faculty
{
    public string Name { get; set; }

    public Department department1;
    public Department department2;

   
    public partial class Department
    {
        private string departmentName;
        private int teacherCount;
        
        private string[] disciplines = new string[5];

        public void SetName(string name)
        {
            this.departmentName = name;
        }

        public void SetTeacherCount(int count)
        {
            this.teacherCount = count;
        }
    }


    public partial class Department
    {
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < disciplines.Length)
                {
                    return disciplines[index];
                }
                return "Невірний індекс";
            }
            set
            {
                if (index >= 0 && index < disciplines.Length)
                {
                    disciplines[index] = value;
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"  Кафедра: {departmentName}, {teacherCount} викладачів.");
            Console.WriteLine("    Дисципліни:");
            
            foreach (string discipline in disciplines)
            {
                if (!string.IsNullOrEmpty(discipline))
                {
                    Console.WriteLine($"    - {discipline}");
                }
            }
        }
    }

    public Faculty(string name)
    {
        this.Name = name;
        this.department1 = new Department();
        this.department2 = new Department();
    }

    public void DisplayFacultyInfo()
    {
        Console.WriteLine($"Факультет: {this.Name}");
        Console.WriteLine(new string('-', 40));

        department1.DisplayInfo();
        Console.WriteLine(); 
        department2.DisplayInfo();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Faculty faculty = new Faculty("Комп'ютерних наук");

        faculty.department1.SetName("Комп. наук та ІПЗ");
        faculty.department1.SetTeacherCount(10);
        
        faculty.department1[0] = "Об'єктно-орієнтоване програмування";
        faculty.department1[1] = "Бази даних";
        faculty.department1[2] = "Алгоритми та структури даних";

        faculty.department2.SetName("ВМ (Вищої математики)");
        faculty.department2.SetTeacherCount(5);

        faculty.department2[0] = "Математичний аналіз";
        faculty.department2[1] = "Лінійна алгебра та аналітична геометрія";

        faculty.DisplayFacultyInfo();

        Console.WriteLine("\nНатисні... будь-яку клавішу для виходу");
        Console.ReadKey();
    }
}

