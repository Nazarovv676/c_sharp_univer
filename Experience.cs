using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Sharp
{
    class Experience
    {
        public Experience()
        {
            PlaceOfWork = "Google";
            Position = "Менеджер";
            DateOfEmployment = new DateTime(2000, 1, 1);
            DateOfDismissal = new DateTime(2000, 12, 31);
        }

        public Experience(string placeOfJob, string position, DateTime start, DateTime finish)
        {
            PlaceOfWork = placeOfJob;
            Position = position;
            DateOfEmployment = start;
            DateOfDismissal = finish;
        }

        public string PlaceOfWork { get; set; }
        public string Position { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfDismissal { get; set; }

        public override string ToString()
        {
            return string.Format($"Place of wotk: {PlaceOfWork} \nPosition: {Position}" +
                $"\nStart date: {DateOfEmployment.ToLongDateString()} \nEnd date: {DateOfDismissal.ToLongDateString()}");
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator == (Experience exp1, Experience exp2)
        {
            return exp1.Equals(exp2);

        }

        public static bool operator != (Experience exp1, Experience exp2)
        {
            return !(exp1.Equals(exp2));
        }

        public object DeepCopy()
        {
            return MemberwiseClone();
        }
    }
}
