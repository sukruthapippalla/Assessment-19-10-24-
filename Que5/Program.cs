namespace Que5
{
    public delegate bool IsEligibleForScholarship(Student std);
    public class Student
    {
        public int RollNo { get; set; }
        public string Name {  get; set; }
        public int Marks {  get; set; }
        public char SportsGrade {  get; set; }
        public static string GetEligibleStudents(List<Student> studentsList, IsEligibleForScholarship isEligible)
        {
            string result = string.Empty;
            foreach (var student in studentsList)
            {
                if (isEligible(student))
                {
                    result += student.Name + ",";
                }
            }
            return result.Remove(result.Length-1);

        }

    }
    
    
    class Program
    {
        
        public static bool ScholarshipEligibility(Student std)
        {
            if(std.Marks > 80 && std.SportsGrade == 'A')
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public static void Main(string[] args)
        {
            IsEligibleForScholarship IsEligible = new IsEligibleForScholarship(ScholarshipEligibility);

            List<Student> lstStudents = new List<Student>();

            Student obj1 = new Student() { RollNo = 1, Name = "Raj", Marks = 75, SportsGrade = 'A' };
            Student obj2 = new Student() { RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A' };
            Student obj3 = new Student() { RollNo = 3, Name = "Kiran", Marks = 89, SportsGrade = 'B' };
            Student obj4 = new Student() { RollNo = 4, Name = "Sunil", Marks = 86, SportsGrade = 'A' };

            lstStudents.Add(obj1);
            lstStudents.Add(obj2);
            lstStudents.Add(obj3);
            lstStudents.Add(obj4);

            Console.WriteLine(Student.GetEligibleStudents(lstStudents, IsEligible));
        }
    }
}
