using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Sharp
{
    class Diploma
    {
        public Diploma()
        {
            Organization = "DNU";
            Qualification = "Software engineer";
            DateOfGraduation = new DateTime(2026, 7, 23);
        }

        public Diploma(string org, string qual, DateTime date)
        {
            Organization = org;
            Qualification = qual;
            DateOfGraduation = date;
        }

        public string Organization { get; set; }
        public string Qualification { get; set; }
        public DateTime DateOfGraduation { get; set; }

        public override string ToString()
        {
            return string.Format($"Qualification: {Qualification} \nOrganization: {Organization} \nDate of graduation: {DateOfGraduation.ToLongDateString()}");
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj?.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator == (Diploma d1, Diploma d2)
        {
            return d1.Equals(d2);

        }

        public static bool operator != (Diploma d1, Diploma d2)
        {
            return !(d1.Equals(d2));
        }

        public object DeepCopy()
        {
            return MemberwiseClone();
        }
    }
}
