using System;
using System.Runtime.InteropServices;

namespace _4_2
{ 

class Program
    {

        [DllImport("D:\\labs\\isp2sem\\lab4\\lab4_2\\Dll2\\x64\\Debug\\Dll2.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int FindMax(int[] a, int m);

        [DllImport("D:\\labs\\isp2sem\\lab4\\lab4_2\\Dll2\\x64\\Debug\\Dll2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float Aver(int[] a, int m);
    static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4 };
         
            Console.WriteLine("Average:" + Aver(array, array.Length));
            Console.WriteLine("Max:" + FindMax(array, array.Length));
        }
    }
}
