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
        public int Age;
        public Student(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
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
                Console.WriteLine("{0, -5} {1, -20} {2, -20} {3, -5}", "#", "Имя", "Фамилия", "Возраст");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -20} {3, -5}", i+1, Students[i].Name, Students[i].Surname, Students[i].Age);
                }
            }
        }
        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"В школу \"{Name}\" успешно добавлен ученик {student.Name}.");
        }

        public void DismissStudent(int number)
        {
            Students.RemoveAt(number-1);
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
                if (GetUserAnswer())
                {
                    school.PrintStudents();
                }
                Console.WriteLine($"Хотите добавить ученика в школу \"{school.Name}\"? Введите да или нет:");
                if (GetUserAnswer())
                {
                    Console.WriteLine("Введите имя ученика:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию ученика:");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Введите возраст ученика:");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Student newStudent = new Student(name, surname, age);
                    school.AddNewStudent(newStudent);
                }
                Console.WriteLine($"Хотите отчислить ученика из школы \"{school.Name}\"? Введите да или нет:");
                if (GetUserAnswer())
                {
                    Console.WriteLine($"Введите номера ученика, которого необходимо отчислить из школы \"{school.Name}\":");
                    int numberDismissedStudent=0;
                    bool isCorrectInput = false;
                    while (isCorrectInput!=true)
                    {
                        if (!Int32.TryParse(Console.ReadLine(), out numberDismissedStudent))
                        {
                            Console.WriteLine("Некорректный ввод! Пожалуйста введите число!");
                        }
                        else if ((numberDismissedStudent < 1))
                        {
                            Console.WriteLine("Некорректный ввод! Номер студента не может быть меньше 1! Пожалуйста, повторите ввод:");
                        }
                        else if (numberDismissedStudent > school.Students.Count)
                        {
                            Console.WriteLine("Некорректный ввод! Номер студента превышает количество учеников! Пожалуйста, повторите ввод:");
                        }
                        else
                        {
                            isCorrectInput = true;
                        }
                    }
                    school.DismissStudent(numberDismissedStudent);
                }
            }
        }
        static bool GetUserAnswer()
        {
            string userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "да")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
