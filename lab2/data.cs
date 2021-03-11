using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            string time1 = now.ToString("F");
            string time2 = now.ToString("g");

            Console.WriteLine("1st format: " + time1);
            CountDigits(time1);
            Console.WriteLine("\n2nd format: " + time2);
            CountDigits(time2);
        }

        static void CountDigits(string time)
        {
            string digits = string.Empty;
            for (int i = 0; i < time.Length; i++)
            {
                int k;
                for (k = 0; k < digits.Length; k++)
                {
                    if (time[i] == digits[k])
                    {
                        break;
                    }

                }
                if (k == digits.Length && time[i] <= '9' && time[i] >= '0')
                {
                    digits += time[i];
                    int counter = 1;
                    for (int j = i + 1; j < time.Length; j++)
                    {
                        if (time[i] == time[j])
                            counter++;
                    }
                    Console.WriteLine($"The number of {time[i]} is {counter}.");
                }
            }
        }

    }
}
