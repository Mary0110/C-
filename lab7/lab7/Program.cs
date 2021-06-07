using System;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction x1 = null, x2 = null;
            bool flag = false;
            while (!flag)
            {
                do
                {
                    Console.WriteLine("Enter first fraction");
                    flag = Fraction.TryParse(Console.ReadLine(), out x1);
                } while (!flag);

                do
                {
                    Console.WriteLine("Enter second fraction");
                    flag = Fraction.TryParse(Console.ReadLine(), out x2);
                } while (!flag);
                flag = true;
            }

            Console.WriteLine($"{x1} + {x2} = {x1 + x2} = {(double)(x1 + x2)}");

            Console.WriteLine($"{x1} - {x2} = {x1 - x2} = {(double)(x1 - x2)}");

            Console.WriteLine($"{x1} * {x2} = {x1 * x2} = {(double)(x1 * x2)}");

            Console.WriteLine($"{x1} / {x2} = {x1 / x2} = {(double)(x1 / x2)}");

            Console.WriteLine($"{x1} == {x2} ? {x1 == x2}");

            Console.WriteLine($"{x1} != {x2} ? {x1 != x2}");

            Console.WriteLine($"{x1} < {x2} ? {x1 < x2}");

            Console.WriteLine($"{x1} > {x2} ? {x1 > x2}");

            Console.WriteLine($"{x1} <= {x2} ? {x1 <= x2}");

            Console.WriteLine($"{x1} >= {x2} ? {x1 >= x2}");
        }
    }
}
