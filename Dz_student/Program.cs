﻿namespace Dz_student;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        string[] names = { 
            "Alice", "Bob", "Charlie", "David", "Emma", 
            "Frank", "Grace", "Henry", "Isla", "Jack", 
            "Kate", "Liam", "Mia", "Noah", "Olivia" 
        };
        string[] surnames = { 
            "Johnson", "Smith", "Brown", "Williams", "Davis", 
            "Miller", "Wilson", "Moore", "Taylor", "Anderson", 
            "Thomas", "White", "Harris", "Martin", "Lewis" 
        };
        Student a = new Student(names[rnd.Next(0, 14)], "middle3", surnames[rnd.Next(0, 14)], "+380678835027");
        Student b = new Student(names[rnd.Next(0, 14)], "middle2", surnames[rnd.Next(0, 14)], "+380678835027");
        Student c = new Student(names[rnd.Next(0, 14)], "middle1", surnames[rnd.Next(0, 14)], "+380678835027");
        Student d = new Student(names[rnd.Next(0, 14)], "middle4", surnames[rnd.Next(0, 14)], "+380678835027");
        Student e = new Student(names[rnd.Next(0, 14)], "middle5", surnames[rnd.Next(0, 14)], "+380678835027");
        
        a.randomGrade(5,10);
        b.randomGrade(5,10);
        c.randomGrade(5,10);
        d.randomGrade(5,10);
        e.randomGrade(5,10);

        Group gr = new Group("software engineering");
        try {
            gr.SetCourse(-1);
        }
        catch {
            gr.SetCourse(1);
        }
        
        gr.addStudent(a);
        gr.addStudent(b);
        gr.addStudent(c);
        gr.addStudent(d);
        gr.addStudent(e);
        
        gr.showInfo();
        Console.WriteLine();
        
        Group gr2 = gr.Clone() as Group;
        gr2.SetSpeciality("engineering");
        
        gr2.showInfo();

        try
        {
            gr2.removeStudent(a);
        }
        catch
        {
            Console.WriteLine("Student not found");
        }
        gr.removeStudent(a);
        gr.showInfo();
        gr2.expelBelow7();
        gr2.showInfo();
        gr2[0].randomGrade(10, 12);
        Console.WriteLine("");
        gr.showInfo();
        gr2.showInfo();
        Console.WriteLine("");
        foreach (Student student in gr)
        {
            Console.WriteLine(student.getFullName());
        }
    }
}

