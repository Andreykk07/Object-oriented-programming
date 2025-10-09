using System;
using System.IO;

namespace Lecture3.Example7
{
    class Person
    {
        int birthYear;
        double pay;

        public Person() 
        {
            Name = "Anonymous";
            birthYear = 0;
            pay = 0;
        }

        public Person(string s) 
        {
            
            string[] parts = s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3)
            {
                throw new FormatException("Рядок має містити принаймні 3 елементи: Ім'я, Рік, Оклад");
            }

            Name = parts[0]; // Прізвище та ініціали
            birthYear = Convert.ToInt32(parts[1]);
            pay = Convert.ToDouble(parts[2]);

            if (birthYear < 0 || pay < 0)
            {
                throw new FormatException("Неприпустиме значення року або окладу");
            }
        }

        public override string ToString()
        {
            return $"Name: {Name,30} birth: {birthYear} pay: {pay:F2}";
        }

        public int Compare(string? name)
        {
            return string.Compare(name, this.Name, StringComparison.OrdinalIgnoreCase);
        }
        public string Name { get; set; }

        public int Birth_year
        {
            get => birthYear;
            set => birthYear = value > 0 ? value : throw new FormatException();
        }

        public double Pay
        {
            get => pay;
            set => pay = value > 0 ? value : throw new FormatException();
        }

        public static double operator +(Person pers, double a)
        {
            pers.pay += a;
            return pers.pay;
        }

        public static double operator +(double a, Person pers)
        {
            pers.pay += a;
            return pers.pay;
        }

        public static double operator -(Person pers, double a)
        {
            pers.pay -= a;
            return pers.pay < 0 ? throw new FormatException() : pers.pay;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] dbase = new Person[100];
            int n = 0;

            try
            {
                using (var f = new StreamReader("Persons.txt"))
                {
                    string s;
                    int i = 0;

                    while ((s = f.ReadLine()) != null)
                    {
                        dbase[i] = new Person(s);
                        Console.WriteLine(dbase[i]);
                        ++i;
                    }

                    n = i;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Перевірте правильність імені і шляху до файлу!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Дуже великий файл!");
                return;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Помилка формату: {e.Message}");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка: {e.Message}");
                return;
            }

            int peopleNumber = 0;
            double meanPay = 0;

            Console.WriteLine("\nВведіть прізвище співробітника (або Enter для завершення):");
            string name;

            while (!string.IsNullOrWhiteSpace(name = Console.ReadLine()))
            {
                bool notFound = true;

                for (int k = 0; k < n; ++k)
                {
                    Person pers = dbase[k];
                    if (pers.Compare(name) == 0)
                    {
                        Console.WriteLine(pers);
                        ++peopleNumber;
                        meanPay += pers.Pay;
                        notFound = false;
                    }
                }

                if (notFound)
                {
                    Console.WriteLine("Такого співробітника немає");
                }

                Console.WriteLine("\nВведіть прізвище співробітника або натисніть Enter для завершення:");
            }

            if (peopleNumber > 0)
            {
                Console.WriteLine("\nСередній оклад: {0:F2}", meanPay / peopleNumber);
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
