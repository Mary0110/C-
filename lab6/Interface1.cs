using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3
{
    public interface IEntertainable
    {
        void EatOut();
        void Celebrate();
    }
    public interface IComparable<T>
    {
        int CompareTo(T other);

    }
}
