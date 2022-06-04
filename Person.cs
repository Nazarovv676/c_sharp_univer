using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Sharp
{
    class Person : IDateAndCopy
    {

        public Person()
        {
            Name = "Ivan";
            Surname = "Belov";
            DateOfBirth = new DateTime(1989, 1, 1);
        }

        public Person(string name, string surname, DateTime date)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = date;
        }

        public string Name
        { get; set; }

        public string Surname
        { get; set; }

        public DateTime DateOfBirth
        { get; set; }

        public int YearOfBirth
        {
            get { return DateOfBirth.Year; }
            set
            {
                DateTime newDateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day);
                DateOfBirth = newDateOfBirth;
            }
        }

        public override string ToString()
        {
            return string.Format($"Name: {Name} \nSurname: {Surname} \nDate of birth: {DateOfBirth.ToLongDateString()}");
        }

        public virtual string ToShortString()
        {
            return string.Format($"Name: {Name} \nSurname: {Surname}");
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator == (Person p1, Person p2)
        {
            return p1.Equals(p2);          
        }

        public static bool operator != (Person p1, Person p2)
        {
            return !(p1.Equals(p2));
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        public DateTime Date { get; set; }
    }
}
