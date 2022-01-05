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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в панель управления! Пожалуйста, введите название вашей школы:");
            string schoolName = Console.ReadLine();
            School school = new School(schoolName);
            Console.WriteLine($"Школа \"{school.Name}\" успешно создана!");
        }
    }
}
