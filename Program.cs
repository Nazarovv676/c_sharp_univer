using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Sharp
{
    enum TimeWork
    {
        FullTime,
        PartTime,
        Free
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lab3Demo();
        }

        private static void Lab3Demo()
        {
            Person p1 = new Person();
            Person p2 = new Person();

            Console.WriteLine("#1");
            Console.WriteLine($"Reference equals: {ReferenceEquals(p1, p2)}");
            Console.WriteLine($"Equals: {p1.Equals(p2)}");
            Console.WriteLine($"First hash code: {p1.GetHashCode()}");
            Console.WriteLine($"Second hash code: {p2.GetHashCode()}");

            Employee emp = new Employee();

            emp.AddDiplomas(new Diploma("KPI", "Engineer", new DateTime(2008, 7, 20)),
            new Diploma("Lviv National University", "Biotech expert", new DateTime(2015, 6, 18)));
            emp.AddExperience(new Experience());

            Console.WriteLine("\n#2");
            Console.WriteLine(emp);

            Console.WriteLine("\n#3");
            Console.WriteLine(emp.Person);

            Console.WriteLine("\n#4");
            Employee emp2 = (Employee)emp.DeepCopy();
            emp.Surname = "Prigojin";
            emp.ListOfDiplomas[0].Organization = "no name school";

            Console.WriteLine("Source object:\n\n" + emp);
            Console.WriteLine("\n\nCopy object:\n\n" + emp2);

            Console.WriteLine("\n#5");
            try
            {
                emp.Salary = 20000;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n#6");
            foreach (object o in emp.GetDiplomasAndExperience())
            {
                Console.WriteLine(o + "\n");
            }

            Console.WriteLine("#7");
            foreach (Diploma d in emp.GetDiplomas(10))
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("\n#8");
            emp.AddExperience(new Experience() { PlaceOfWork = "Facebook", DateOfEmployment = new DateTime(2016, 7, 12), DateOfDismissal = new DateTime(2017, 4, 30) },
                              new Experience() { PlaceOfWork = "Yahoo", DateOfEmployment = new DateTime(2018, 5, 1), DateOfDismissal = new DateTime(2018, 11, 30) });
            foreach (string org in emp)
            {
                Console.WriteLine(org);
            }

            Console.WriteLine("\n#9");
            emp2.AddExperience(new Experience() { Position = "Accountant" },
                               new Experience() { PlaceOfWork = "Yandex", Position = "Accountant" });

            foreach (string org in emp2.GetOrganizationByPositon("Accountant"))
            {
                Console.WriteLine(org);
            }
        }
    }
}
