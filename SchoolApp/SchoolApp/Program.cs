using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    public class Student
    {
        public string Name;
        public string Surname;

        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
    public class School
    {
        public string Name;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine($"В школе \"{Name}\" пока нет учеников!");
            }
            else
            {
                Console.WriteLine("{0, -20} {1, -20}", "Имя", "Фамилия");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine("{0, -20} {1, -20}", Students[i].Name, Students[i].Surname);
                }
            }
        }
        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"В школу \"{Name}\" успешно добавлен ученик {student.Name}.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в панель управления! Пожалуйста, введите название вашей школы:");
            string schoolName = Console.ReadLine();
            School school = new School(schoolName);
            Console.WriteLine($"Школа \"{school.Name}\" успешно создана!");
            while (true)
            {
                Console.WriteLine($"Отобразить список учеников школы \"{school.Name}\"? Введите да или нет:");
                string userAnswer = Console.ReadLine();
                if (userAnswer == "да")
                {
                    school.PrintStudents();
                }
                Console.WriteLine($"Хотите добавить ученика в школу \"{school.Name}\"? Введите да или нет:");
                userAnswer = Console.ReadLine();
                if (userAnswer == "да")
                {
                    Console.WriteLine("Введите имя ученика:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию ученика:");
                    string surname = Console.ReadLine();
                    Student newStudent = new Student(name, surname);
                    school.AddNewStudent(newStudent);
                }
            }
        }
    }
}
