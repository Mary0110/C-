using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str;
            Console.WriteLine("Enter string:");
            str = new StringBuilder(Console.ReadLine());
            ReverseString(str);
        }
        static void ReverseString(StringBuilder s)
        {
            List<StringBuilder> t = new List<StringBuilder>();
            StringBuilder word = new StringBuilder("");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    t.Add(word);
                    word = new StringBuilder("");
                }
                else
                    word.Append(s[i]);
            }

            t.Add(word);
            t.Reverse();
            Console.WriteLine();

            for (int i = 0; i < t.Count; i++)
                Console.Write($"{t[i]}  ");
        }
    }

}
