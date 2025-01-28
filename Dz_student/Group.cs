namespace Dz_student;

class Group
{
    private string name;
    private string groupSpeciality;
    private int course;
    private List<Student> students;

    public Group()
    {
        students = new List<Student>();
        course = 1;
    }

    public Group(string groupSpeciality) : base()
    {
        this.groupSpeciality = groupSpeciality;
    }

    public Group(string groupSpeciality, string name) : this(groupSpeciality)
    {
        this.name = name;
    }
    public void showInfo()
    {
        Console.WriteLine("Group name: {0}", name);
        Console.WriteLine("Group speciality: {0}", groupSpeciality);
        Console.WriteLine("Course: {0}", course);
        students.Sort();
        foreach (var i in students)
        {
            Console.Write("{0}: {1} {2}, Avg.: {3}, ", i.getPhoneNumber(), i.getFirstName(), i.getLastName(), (int)i.averageGrade());
        }
    }

    public void addStudent(Student student)
    {
        if (!students.Contains(student))
        {
            students.Add(student);
        }
    }

    public void removeStudent(Student student)
    {
        if (students.Contains(student))
        {
            students.Remove(student);
        }
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetSpeciality(int speciality)
    {
        this.groupSpeciality = speciality.ToString();
    }

    public void SetCourse(int course)
    {
        this.course = course;
    }

    public void expelBelow7()
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].averageGrade() < 7)
            {
                students.Remove(students[i]);
                i--;
            }
        }
    }

    public void expelLowest()
    {
        if (students.Count == 0) return;
        
        Student student = students[0];
        foreach (var i in students)
        {
            if (i.averageGrade() < student.averageGrade())
            {
                student = i;
            }
        }
        students.Remove(student);
    }

    public void Move(Group group, Student student)
    {
        if (students.Contains(student) && !group.students.Contains(student))
        {
            students.Remove(student);
            group.students.Add(student);
        }
    }
    
    public static bool operator true (Group group) {return group.students.Count != 0;}
    public static bool operator false (Group group) {return group.students.Count == 0;}
    public static bool operator > (Group group1, Group group2) {return group1.students.Count() > group2.students.Count();}
    public static bool operator < (Group group1, Group group2) {return group1.students.Count() < group2.students.Count();}
    public static bool operator == (Group group1, Group group2) {return group1.students.Count() == group2.students.Count();}
    public static bool operator != (Group group1, Group group2) {return group1.students.Count() != group2.students.Count();}

    public Student this[int i]
    {
        get { return students[i]; }
    }
}