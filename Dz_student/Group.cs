using System.Collections;

namespace Dz_student;

class Group: ICloneable, IEnumerable
{
    // для строк не делал
    public string _name
    {
        get { return new string(name); }
        private set { SetName(value);  }
    }
    private string name;

    public string _groupSpeciality
    {
        get {return new string(groupSpeciality);}
        private set { SetSpeciality(value); }
    }
    private string groupSpeciality;

    public int _course
    {
        get { return course; } 
        private set { SetCourse(value); }
    }
    private int course;

    
    public List<Student> _students
    {
        get { return new List<Student>(students); }
    }
    private List<Student> students;


    public Group()
    {
        students = new List<Student>();
        SetCourse(0);
    }
    public Group(string groupSpeciality) : this()
    {
        SetSpeciality(groupSpeciality);
    }
    public Group(string groupSpeciality, string name) : this(groupSpeciality)
    {
        SetName(name);
    }
    
    
    public void showInfo()
    {
        Console.WriteLine("Group name: {0}", name);
        Console.WriteLine("Group speciality: {0}", groupSpeciality);
        Console.WriteLine("Course: {0}", course);
        students.Sort();
        foreach (var i in students)
        {
            Console.Write("{0}: {1} {2}, Avg.: {3}, \n", i.getPhoneNumber(), i.getFirstName(), i.getLastName(), (int)i.averageGrade());
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
        else
        {
            throw new Exception("Student not found");
        }
    }

    public void SetName(string name)
    {
        this.name = new string(name);
    }

    public void SetSpeciality(string speciality)
    {
        this.groupSpeciality = new string(speciality);
    }

    public void SetCourse(int course)
    {
        this.course = course >= 0 ? course : throw new Exception("course must be greater or equal to 0.");
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

    public object Clone()
    {
        Group gr = new Group(_groupSpeciality, _name);
        gr.SetCourse(_course);
        foreach (var student in students) { gr.addStudent(student.Clone() as Student); }

        return gr;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new StudentEnumerator(students);
    }
    
    private class StudentEnumerator : IEnumerator
    {
        private List<Student> _students;
        private int position = -1;

        public StudentEnumerator(List<Student> students)
        {
            _students = students;
        }

        public bool MoveNext()
        {
            position++;
            return position < _students.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Student Current
        {
            get
            {
                try
                {
                    return _students[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public void Sort(IComparer<Student> comparer)
    {
        students.Sort(comparer);
    }
}