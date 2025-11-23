using System;
using System.Collections.Generic;

namespace Lecture8.Example4
{
    public class Animal
    {
        private string name;
        private string species;
        private int age;

        public Animal(string name, string species, int age)
        {
            this.name = name;
            this.species = species;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return $"Тварина: {Name} (Вид: {Species}, Вік: {Age})";
        }
    }

    public class GenericList<T> where T : Animal
    {
        private class Node
        {
            private Node next;
            private T data;

            public Node(T t)
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        public GenericList()
        {
            head = null;
        }

        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T FindFirstOccurrence(string s)
        {
            Node current = head;
            T foundAnimal = null;

            while (current != null)
            {
                if (current.Data.Name.Equals(s, StringComparison.OrdinalIgnoreCase))
                {
                    foundAnimal = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return foundAnimal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<Animal> animalList = new GenericList<Animal>();

            animalList.AddHead(new Animal("Рекс", "Собака", 5));
            animalList.AddHead(new Animal("Мурка", "Кішка", 3));
            animalList.AddHead(new Animal("Зірочка", "Хом'як", 1));
            animalList.AddHead(new Animal("Рекс", "Вівчарка", 7)); 

            Console.WriteLine("--- Список тварин ---");
            foreach (var animal in animalList)
            {
                Console.WriteLine(animal);
            }
            
            Console.WriteLine("\n--------------------");
            
            string searchName = "Мурка";
            Animal found = animalList.FindFirstOccurrence(searchName);

            if (found != null)
            {
                Console.WriteLine($"Знайдено тварину з іменем '{searchName}':");
                Console.WriteLine(found);
            }
            else
            {
                Console.WriteLine($"Тварину з іменем '{searchName}' не знайдено.");
            }
            
            Console.WriteLine("\n--------------------");
            
            string searchName2 = "Рекс";
            Animal found2 = animalList.FindFirstOccurrence(searchName2);
            Console.WriteLine($"Знайдено першу тварину з іменем '{searchName2}':");
            Console.WriteLine(found2);


            Console.ReadKey();
        }
    }
}
