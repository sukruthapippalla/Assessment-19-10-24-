namespace Que1
{
    class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age {  get; set; }

    }
    class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            string res = string.Empty;
            foreach (Person p in person)
            {
                res += p.Name + " " + p.Address + " ";
            }
            return res;
        }

        public double Average(IList<Person> person)
        {
            double sum = 0;
            double count = person.Count;
            foreach (Person p in person)
            {
                sum += p.Age;
            }
            return sum / count;
        }
        public int Max(IList<Person> person)
        {
            int max = 0;
            foreach (Person p in person)
            {
                if(p.Age > max)
                {
                    max = p.Age;
                }
            }
            return max;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            PersonImplementation personImplementation = new PersonImplementation();

            IList<Person> p = new List<Person>();
            p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
            p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
            p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
            p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });

            Console.WriteLine(personImplementation.GetName(p));
            Console.WriteLine(personImplementation.Average(p));
            Console.WriteLine(personImplementation.Max(p));
        }
    }
}
