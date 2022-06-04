using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Sharp
{
    class EmployeeEnumerator : IEnumerator
    {
        List<Experience> exp = new List<Experience>();
        int index = -1;

        public EmployeeEnumerator(List<Experience> ex)
        {
            exp.AddRange(ex);
        }

        public bool MoveNext()
        {
            while (index < exp.Count - 1)
            {
                index++;
                if (exp[index].DateOfDismissal.Subtract(exp[index].DateOfEmployment).TotalDays < 365)
                    return true;
            }

            Reset();
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return exp[index].PlaceOfWork;
            }
        }
    }
}
