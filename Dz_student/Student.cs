namespace Dz_student;

class Student : IComparable<Student>
{
    public string _firstName
    {
        get { return new string(firstName); }
        private set { setFirstName(value); }
    } 
    private string firstName; // имя
    
    public string _middleName
    {
        get { return new string(middleName); }
        private set { setMiddleName(value); }
    }
    private string middleName; // отчество
    
    public string _lastName
    {
        get { return new string(lastName); } 
        private set { setLastName(value); }
    }
    private string lastName; // фамилия
    
    
    public DateTime _dateOfBirth
    {
        get {return new DateTime(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day);}
        private set { setDateOfBirth(value); }
    }
    private DateTime dateOfBirth;
    
    public string _homeAddress
    {
        get { return new string(_homeAddress); }
        private set { setHome(value); }
    }
    private string homeAddress;
    
    public string _phoneNumber
    {
        get { return new string(phoneNumber); }
        private set { setPhoneNumber(value); }
    }
    private string phoneNumber;

    
    public List<int> _grades {
        get { return new List<int>(grades); }
    }
    private List<int> grades;
    
    public List<int> _tests {
        get { return new List<int>(tests); }
    }
    private List<int> tests;
    
    public List<int> _exams {
        get { return new List<int>(exams); }
    }
    private List<int> exams;

    public Student(string firstName, string middleName, string lastName, string phoneNumber)
    {
        setFirstName(firstName);
        setMiddleName(middleName);
        setLastName(lastName);
        setPhoneNumber(phoneNumber);
        grades = new List<int>();
        tests = new List<int>();
        exams = new List<int>();
    }

    public Student(string firstName, string middleName, string lastName, string homeAddress, string phoneNumber, DateTime dateOfBirth) 
        : this(firstName, middleName, lastName, phoneNumber)
    {
        setDateOfBirth(dateOfBirth);
        setHome(homeAddress);
    }

    public void setFirstName(string firstName)
    {
        this.firstName = firstName;
    }

    public void setMiddleName(string middleName)
    {
        this.middleName = middleName;
    }

    public void setLastName(string lastName)
    {
        this.lastName = lastName;
    }

    public void setDateOfBirth(DateTime dateOfBirth)
    {
        this.dateOfBirth = dateOfBirth.AddYears(16).CompareTo(DateTime.Now) != 1 ? dateOfBirth : throw new Exception("Student must be at least 16yo.");;
    }

    public void setHome(string homeAddress)
    {
        this.homeAddress = homeAddress;
    }

    public void setPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    public void addGrade(int grade)
    {
        this.grades.Add(grade);
    }

    public void addGrades(List<int> grades)
    {
        this.grades.AddRange(grades);
    }

    public void addTest(int test)
    {
        this.tests.Add(test);
    }

    public void addTests(List<int> tests)
    {
        this.tests.AddRange(tests);
    }

    public void addExam(int exam)
    {
        this.exams.Add(exam);
    }

    public void addExams(List<int> exams)
    {
        this.exams.AddRange(exams);
    }

    public string getFirstName()
    {
        return this.firstName;
    }

    public string getMiddleName()
    {
        return this.middleName;
    }

    public string getLastName()
    {
        return this.lastName;
    }

    public DateTime getDateOfBirth()
    {
        return this.dateOfBirth;
    }

    public string getHomeAddress()
    {
        return this.homeAddress;
    }

    public string getPhoneNumber()
    {
        return this.phoneNumber;
    }

    public List<int> getGrades()
    {
        return this.grades;
    }

    public List<int> getTests()
    {
        return this.tests;
    }

    public List<int> getExams()
    {
        return this.exams;
    }
    public void showInfo()
    {
        Console.WriteLine("First Name: {0}", this.firstName);
        Console.WriteLine("Middle Name: {0}", this.middleName);
        Console.WriteLine("Last Name: {0}", this.lastName);
        Console.WriteLine("Phone Number: {0}", this.phoneNumber);
        Console.WriteLine("Date Of Birth: {0}", this.dateOfBirth.ToString("dd/MM/yyyy"));
        Console.WriteLine("Home Address: {0}", this.homeAddress);
        Console.WriteLine("Grades: {0}", string.Join(", ", grades));
        Console.WriteLine("Tests: {0}", string.Join(", ", tests));
        Console.WriteLine("Exams: {0}", string.Join(", ", exams));
    }

    public override string ToString()
    {
        return this.lastName + ", " + this.firstName + ", " + this.middleName + ", " + this.phoneNumber + ", " + this.dateOfBirth.ToString("dd/MM/yyyy");
    }

    public double averageGrade()
    {
        return (grades.Average() + tests.Average() + exams.Average())/3;
    }

    public int CompareTo(Student other)
    {
        return lastName.CompareTo(other.lastName);
    }

    public void randomGrade(int low, int high)
    {
        Random random = new Random();
        int gradesAmount = random.Next(3, 7);
        for (int i = 0; i < gradesAmount; i++)
        {
            grades.Add(random.Next(low, high));
        }
        gradesAmount = random.Next(3, 7);
        for (int i = 0; i < gradesAmount; i++)
        {
            tests.Add(random.Next(low, high));
        }
        gradesAmount = random.Next(3, 7);
        for (int i = 0; i < gradesAmount; i++)
        {
            exams.Add(random.Next(low, high));
        }
    }
    
    public static bool operator true(Student student) { return student.averageGrade() >= 7; }
    public static bool operator false (Student student) { return student.averageGrade() < 7; }
    
    public static bool operator > (Student student1, Student student2) {return student1.averageGrade() > student2.averageGrade();}
    public static bool operator < (Student student1, Student student2) {return student1.averageGrade() < student2.averageGrade();}
    
    public static bool operator == (Student student1, Student student2) {return student1.averageGrade() == student2.averageGrade();}
    public static bool operator != (Student student1, Student student2) {return student1.averageGrade() != student2.averageGrade();}

}