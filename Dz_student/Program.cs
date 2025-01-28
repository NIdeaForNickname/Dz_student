namespace Dz_student;

class Program
{
    static void Main(string[] args)
    {
        Student a = new Student("first3", "middle3", "last3", "+380678835027");
        Student b = new Student("first2", "middle2", "last2", "+380678835027");
        Student c = new Student("first1", "middle1", "last1", "+380678835027");
        Student d = new Student("first4", "middle4", "last4", "+380678835027");
        Student e = new Student("first5", "middle5", "last5", "+380678835027");
        
        a.randomGrade(3,12);
        b.randomGrade(3,12);
        c.randomGrade(3,12);
        d.randomGrade(3,12);
        e.randomGrade(3,12);
        
        a.addGrade(0);

        Group gr = new Group();
        
        gr.addStudent(a);
        gr.addStudent(b);
        gr.addStudent(c);
        gr.addStudent(d);
        gr.addStudent(e);
        
        gr.showInfo();
        Console.WriteLine();
        
        gr.expelBelow7();
        gr.showInfo();
        Console.WriteLine();
        
        gr.expelLowest();
        gr.showInfo();
        Console.WriteLine();
    }
}

