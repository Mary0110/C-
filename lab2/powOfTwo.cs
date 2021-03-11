using System;

namespace powOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a:");
            
            ulong a;
            while (!ulong.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Invalid input of a. Try again:");
                      
            }

            Console.WriteLine("Enter b:");
            ulong b;
            while (!ulong.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Invalid input of b. Try again:");

            }

            if(a > b)
            {
                ulong t;
                t = a;
                a = b;
                b = t;
                Console.WriteLine("We swapped a and b as you entered a > b");
            }

            ulong res = 0;

            if (a != 0)
            {
                if (a % 2 == 0)
                    a--;

                ulong res1 = 0;
                while (a > 0)
                {
                    a /= 2;
                    res1 += a;
                }

                ulong res2 = 0;
                while (b > 0)
                {
                    b /= 2;
                    res2 += b;
                }

                res = res2 - res1;
            }
            Console.WriteLine("Maximum power of 2: " + res);
        }
    }
}
