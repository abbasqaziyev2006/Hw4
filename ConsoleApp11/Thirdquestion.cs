namespace ConsoleApp11
{
    internal class Thirdquestion
    {
        static Storage studentStorage = new Storage();

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("[0]: All students");
                Console.WriteLine("[1]: Add student");
                Console.WriteLine("[2]: Update student");
                Console.WriteLine("[3]: Remove student");
                Console.WriteLine("[4]: Exit");

                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        studentStorage.PrintStudents();
                        break;
                    case "1":
                        studentStorage.Add();
                        break;
                    case "2":
                        studentStorage.Update();
                        break;
                    case "3":
                        studentStorage.Remove();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("This is not a correct.");
                        break;
                }
            } while (true);
        }
    }

    public class Student
    {
        private static int _autoIncrementId = 1;

        public Student(string name, int age, string grade)
        {
            Id = _autoIncrementId++;
            Name = name;
            Age = age;
            Grade = grade;
        }

        public string Name { get; set; }
        public int Id { get; }
        public int Age { get; set; }
        public string Grade { get; set; }
    }

    public class Storage
    {
        private Student[] _students = new Student[5];
        private int _size = 0;

        public void PrintStudents()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"Id",-4} {"Name",-20} {"Age",-10} {"Grade"}");
            for (int i = 0; i < _size; i++)
            {
                var student = _students[i];
                Console.WriteLine(new string('-', 60));
                Console.WriteLine($"{student.Id,-4} {student.Name,-20} {student.Age,-10} {student.Grade}");
            }
            Console.WriteLine(new string('-', 60));
        }

        public void Add()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age=int.Parse(Console.ReadLine());
            Console.Write("Grade: ");
            string grade = Console.ReadLine();
            var student = new Student(name, age, grade);

            if (_size >= _students.Length)
            {
                Student[] tmpStudents = new Student[_students.Length * 2];
                Array.Copy(_students, tmpStudents, _students.Length);
                _students = tmpStudents;
            }

            _students[_size++] = student;
            Console.WriteLine("Student added.");
        }

        public void Update()
        {
            Console.Write("Id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            for (int i = 0; i < _size; i++)
            {
                if (_students[i].Id == id)
                {
                    Console.Write($"Old Name: {_students[i].Name} ");
                    string name = Console.ReadLine();
                    Console.Write($"Old Age: {_students[i].Age} ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write($"Old Grade: {_students[i].Grade} ");
                    string grade = Console.ReadLine();

                    _students[i].Name = name;
                    _students[i].Age = age;
                    _students[i].Grade = grade;
                    Console.WriteLine("Successfully updated.");
                    return;
                }
            }

            Console.WriteLine("Student not found.");
        }

        public void Remove()
        {
            Console.Write("Id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            for (int i = 0; i < _size; i++)
            {
                if (_students[i].Id == id)
                {
                    for (int j = i; j < _size - 1; j++)
                    {
                        _students[j] = _students[j + 1];
                    }

                    _students[--_size] = null;
                    Console.WriteLine("Successfully removed.");
                    return;
                }
            }

            Console.WriteLine("Student not found.");
        }
    }
}
