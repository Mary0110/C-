using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Enter string:");
            str = Console.ReadLine();
            reverseString(str);
        }
        static void reverseString(string s)
        {
            List<string> t = new List<string>();
            string word = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    t.Add(word);
                    word = string.Empty;
                }
                else
                    word += s[i];
            }

            t.Add(word);
            t.Reverse();
            
            for (int i = 0; i < t.Count; i++)
                Console.Write($"{t[i]}  ");
        }
    }

}
