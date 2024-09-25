using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string lastName;
    private string firstName;
    private string middleName;
    private DateTime birthDate;
    private string homeAddress;
    private string phoneNumber;

    private List<int> homeworkGrades;
    private List<int> courseGrades;
    private List<int> examGrades;

    public Student()
    {
        lastName = "";
        firstName = "";
        middleName = "";
        birthDate = DateTime.MinValue;
        homeAddress = "";
        phoneNumber = "";
        homeworkGrades = new List<int>();
        courseGrades = new List<int>();
        examGrades = new List<int>();
    }

    public Student(string lastName, string firstName, string middleName, DateTime birthDate, string homeAddress, string phoneNumber)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.middleName = middleName;
        this.birthDate = birthDate;
        this.homeAddress = homeAddress;
        this.phoneNumber = phoneNumber;
        this.homeworkGrades = new List<int>();
        this.courseGrades = new List<int>();
        this.examGrades = new List<int>();
    }

    public List<int> HomeworkGrades => homeworkGrades;
    public List<int> CourseGrades => courseGrades;
    public List<int> ExamGrades => examGrades;

    public static bool operator true(Student student)
    {
        return student.homeworkGrades.Count > 0 || student.courseGrades.Count > 0 || student.examGrades.Count > 0;
    }

    public static bool operator false(Student student)
    {
        return student.homeworkGrades.Count == 0 && student.courseGrades.Count == 0 && student.examGrades.Count == 0;
    }
    public static bool operator ==(Student s1, Student s2)
    {
        return s1.lastName == s2.lastName && s1.firstName == s2.firstName && s1.middleName == s2.middleName;
    }

    public static bool operator !=(Student s1, Student s2)
    {
        return !(s1 == s2);
    }

    public static bool operator >(Student s1, Student s2)
    {
        return s1.GetAverageGrade() > s2.GetAverageGrade();
    }

    public static bool operator <(Student s1, Student s2)
    {
        return s1.GetAverageGrade() < s2.GetAverageGrade();
    }

    public double GetAverageGrade()
    {
        var allGrades = homeworkGrades.Concat(courseGrades).Concat(examGrades).ToList();
        return allGrades.Count > 0 ? allGrades.Average() : 0;
    }
    public override bool Equals(object obj)
    {
        if (obj is Student)
        {
            return this == (Student)obj;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return lastName.GetHashCode() ^ firstName.GetHashCode() ^ middleName.GetHashCode();
    }

    public void DisplayStudentInfo()
    {
        Console.WriteLine($"Фамилия: {lastName}, Имя: {firstName}, Отчество: {middleName}");
        Console.WriteLine($"Средний балл: {GetAverageGrade()}");
    }
}

public class Group
{
    private List<Student> students;

    public Group()
    {
        students = new List<Student>();
    }

    public Group(List<Student> students)
    {
        this.students = students;
    }

    public static bool operator ==(Group g1, Group g2)
    {
        if (g1.students.Count != g2.students.Count) return false;

        for (int i = 0; i < g1.students.Count; i++)
        {
            if (g1.students[i] != g2.students[i])
                return false;
        }
        return true;
    }

    public static bool operator !=(Group g1, Group g2)
    {
        return !(g1 == g2);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("|♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥|");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Student student1 = new Student("Демидов", "Артур", "Иванович", new DateTime(2004, 3, 15), "ул Преображенская 4", "380-97-39-55-211");
        Student student2 = new Student("Черенков", "Петр", "Архипович", new DateTime(1999, 4, 11), "ул Гвардейская 11а", "380-66-53-22-423");

        student1.HomeworkGrades.Add(5);
        student1.CourseGrades.Add(4);
        student1.ExamGrades.Add(5);

        student2.HomeworkGrades.Add(3);
        student2.CourseGrades.Add(3);
        student2.ExamGrades.Add(4);

        if (student1)
        {
            student1.DisplayStudentInfo();
        }
        Console.WriteLine(student1 == student2 ? "Студенты равны" : "Студенты не равны");
        Console.WriteLine(student1 > student2 ? "Студент 1 имеет лучший средний балл" : "Студент 2 имеет лучший средний балл");
        Group group1 = new Group(new List<Student> { student1, student2 });
        Group group2 = new Group(new List<Student> { student1, student2 });

        Console.WriteLine(group1 == group2 ? "Группы равны" : "Группы не равны");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("|♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥|");
        Console.ForegroundColor = ConsoleColor.Gray;

    }
}
