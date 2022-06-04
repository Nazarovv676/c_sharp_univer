using System.Collections;

namespace Lab4Sharp
{
    enum TimeWork
    {
        FullTime,
        PartTime,
        Free
    }

    class Employee : Person, IEnumerable
    {
        private string position;
        private TimeWork timeWork;
        private int salary;
        private List<Diploma> listOfDiplomas = new List<Diploma>();
        private List<Experience> experiences = new List<Experience>();  

        public Employee()
        {
            Person = new Person();
            Position = "Manager";
            TimeWork = TimeWork.Free;
            Salary = 1500;
        }

        public Employee(Person person, string position, TimeWork timework, int salary) 
            : base (person.Name, person.Surname, person.DateOfBirth)
        {
            Position = position;
            TimeWork = timework;
            Salary = salary;
        }

        public Person Person
        {
            get
            {
                return new Person(Name, Surname, DateOfBirth);
            }
            set
            {
                Name = value.Name;
                Surname = value.Surname;
                DateOfBirth = value.DateOfBirth;
            }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public TimeWork TimeWork
        {
            get { return timeWork; }
            set { timeWork = value; }
        }

        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value <= 0 || value > 2000)
                {
                    throw new ArgumentOutOfRangeException();
                }
                salary = value;
            }
        }

        public List<Diploma> ListOfDiplomas
        {
            get { return listOfDiplomas; }
            set { listOfDiplomas = value; }
        }

        public List<Experience> Experiences
        {
            get { return experiences; }
            set { experiences = value; }
        }

        public Diploma TheLastDiploma
        {
            get
            {
                if (ListOfDiplomas.Count != 0)
                {
                    DateTime maxYear = ListOfDiplomas[0].DateOfGraduation;
                    int index = 0;
                    for (int i = 1; i < ListOfDiplomas.Count; i++)
                        if (ListOfDiplomas[i].DateOfGraduation.Year > maxYear.Year)
                        {
                            maxYear = ListOfDiplomas[i].DateOfGraduation;
                            index = i;
                        }
                    return ListOfDiplomas[index];
                }
                else return  null;
            }
        }

        public void AddDiplomas(params Diploma[] diplomas)
        {
            ListOfDiplomas.AddRange(diplomas); 
        }

        public void AddExperience(params Experience[] experience)
        {
            Experiences.AddRange(experience);
        }

        public override string ToString()
        {
            string education = "";
            string experience = "";
            foreach (Diploma d in ListOfDiplomas)
            {
                education += "\n\n" + d.ToString();
            }
            foreach (Experience e in Experiences)
            {
                experience += "\n\n" + e.ToString();
            }

            return string.Format($"{Person} \nPosition: {Position} \nTimeWork: {TimeWork} \nSalary: {Salary:f2}" +
                $"\n\nEducation: {education} \n\nExpirience: {experience}");
        }

        public override string ToShortString()
        {
            return string.Format($"{Person} \nPosition: {Position} \nTimeWork: {TimeWork} \nSalary: {Salary:f2}" +
                $"\nDiplomas count: {ListOfDiplomas.Count}");
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator == (Employee emp1, Employee emp2)
        {
            return emp1.Equals(emp2);

        }

        public static bool operator != (Employee emp1, Employee emp2)
        {
            return !(emp1.Equals(emp2));
        }

        public override object DeepCopy()
        {
            Employee newEmp = (Employee)this.MemberwiseClone();
            List<Diploma> newListOfDiplomas = new List<Diploma>();
            List<Experience> newExperiences = new List<Experience>();

            foreach (Diploma d in this.ListOfDiplomas)
            {
                newListOfDiplomas.Add((Diploma)d.DeepCopy());
            }

            foreach (Experience e in this.Experiences)
            {
                newExperiences.Add((Experience)e.DeepCopy());
            }

            newEmp.ListOfDiplomas = newListOfDiplomas;
            newEmp.Experiences = newExperiences;
            return newEmp;
        }

        public IEnumerable GetDiplomasAndExperience()
        {
            foreach (Diploma d in ListOfDiplomas)
            {
                yield return d;
            }

            foreach (Experience e in Experiences)
            {
                yield return e;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new EmployeeEnumerator(Experiences);   
        }

        public IEnumerable GetDiplomas(int n)
        {
            foreach (Diploma d in ListOfDiplomas)
            {
                int CurrentYear = DateTime.Now.Year;
                if ((CurrentYear - d.DateOfGraduation.Year) <= n) 
                    yield return d;
            }
        }

        public IEnumerable GetOrganizationByPositon(string pos)
        {
            foreach (Experience e in Experiences)
            {
                if (e.Position == pos)
                    yield return e.PlaceOfWork;
            }
        }
    }
}
