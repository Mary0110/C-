using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3
{
    class Comp<T> : IComparer<T>
        where T : Migrant
    {
        public int Compare(T first, T second)
        {
            if (first.Experience.CompareTo(second.Experience) != 0)
            {
                return first.Experience.CompareTo(second.Experience);
            }
            else if (first.Age.CompareTo(second.Age) != 0)
            {
                return second.Age.CompareTo(first.Age);
            }
            else
            {
                return 0;
            }
        }
    }
}
