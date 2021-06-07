using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Text;

namespace lab7
{
    class Fraction : IComparable, IEquatable<Fraction>
    {
            private int _num;
            private int _denum;

            public Fraction(int numerator, int denominator)
            {
                _num = numerator;
                _denum = denominator;
            }

            ~Fraction() { }


            public static bool TryParse(string str, out Fraction fraction)
            {
                Regex pattern = new Regex(@"^-?[0-9]{1,9}/|,[0-9]{1,9}$");
                fraction = null;

                if (pattern.IsMatch(str))
                {
                    string[] numParts = str.Split('/');

                    if (numParts.Length == 2)
                    {
                        fraction = new Fraction(Convert.ToInt32(numParts[0]), Convert.ToInt32(numParts[1]));
                    }
                    else
                    {
                        numParts = str.Split(',');

                        if (numParts.Length == 2)
                        {
                            int numerator = Convert.ToInt32(numParts[0]);
                            int numOfTens = 0;

                            foreach (char c in numParts[1])
                            {
                                if (numParts[0][0] == '-')
                                    numerator = numerator * 10 - (c - '0');
                                else
                                    numerator = numerator * 10 + c - '0';
                                numOfTens++;
                            }
                            fraction = new Fraction(numerator, (int)Math.Pow(10, numOfTens));
                        }
                        else
                        {
                            fraction = new Fraction(Convert.ToInt32(numParts[0]), 1);
                        }
                    }
                    return true;
                }
                return false;
            }


            private int GetGSD(int x1, int x2)
            {
                if (x1 % x2 == 0)
                    return x2;
                if (x2 % x1 == 0)
                    return x1;
                if (x1 > x2)
                    return GetGSD(x1 % x2, x2);
                return GetGSD(x1, x2 % x1);
            }

            private void Simplify()
            {
                if (_num != 0)
                {
                    int devider = GetGSD(Math.Abs(_num), Math.Abs(_denum));
                    _num /= devider;
                    _denum /= devider;
                }
            }

            public static Fraction operator +(Fraction num1, Fraction num2)
            {
                int newNumerator = num1._num * num2._denum + num2._num * num1._denum;
                int newDenominator = num1._denum * num2._denum;
                Fraction result = new Fraction(newNumerator, newDenominator);

                return result;
            }

            public static Fraction operator -(Fraction x1)
            {
                return new Fraction(-x1._num, x1._denum);
            }

            public static Fraction operator -(Fraction x1, Fraction x2)
            {
                return x1 + (-x2);
            }

            public static Fraction operator *(Fraction x1, Fraction x2)
            {
                int newNumerator = x1._num * x2._num;
                int newDenominator = x1._denum * x2._denum;
                Fraction result = new Fraction(newNumerator, newDenominator);

                return result;
            }

            public static Fraction operator /(Fraction x1, Fraction x2)
            {
                int newNumerator = x1._num * x2._denum;
                int newDenominator = x1._denum * x2._num;
                Fraction result = new Fraction(newNumerator, newDenominator);

                return result;
            }

            public static implicit operator double(Fraction num)
            {
                return (double)num._num / num._denum;
            }

            public static explicit operator int(Fraction num)
            {
                return num._num / num._denum;
            }

            public int CompareTo(object obj)
            {
                Fraction anotherFraction = obj as Fraction;

                if ((double)_num / _denum < anotherFraction)
                    return -1;
                if ((double)_num / _denum > anotherFraction)
                    return 1;
                return 0;
            }

            public bool Equals(Fraction anotherFraction)
            {
                if (anotherFraction is null)
                    return false;
                return (double)_num / _denum == anotherFraction;
            }

            public static bool operator <(Fraction x1, Fraction x2)
            {
                return x1 < (double)x2;
            }

            public static bool operator >(Fraction x1, Fraction x2)
            {
                return x1 > (double)x2;
            }

            public static bool operator >=(Fraction x1, Fraction x2)
            {
                return x1 >= (double)x2;
            }

            public static bool operator <=(Fraction x1, Fraction x2)
            {
                return x1 <= (double)x2;
            }

            public static bool operator ==(Fraction x1, Fraction x2)
            {
                return x1.Equals(x2);
            }

            public static bool operator !=(Fraction x1, Fraction x2)
            {
                return !x1.Equals(x2);
            }

            public override string ToString()
            {
                Simplify();
                string res = _num == 0 ? "0"
                    : _denum == 1 ? $"{_num}"
                    : $"{_num}/{_denum}";

                return res;
            }
        }
}
