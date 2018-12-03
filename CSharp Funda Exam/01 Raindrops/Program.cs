using System;
using System.Linq;

namespace _01_Raindrops
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            decimal dencity = decimal.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine().Split().Select(long.Parse).ToArray();
                long raindropsCount = arr[0];
                double squareMeters = arr[1];
                if (squareMeters != 0)
                {
                    sum += raindropsCount / (decimal)squareMeters;
                }
            }
            decimal coefficient = 0;
            if (dencity != 0)
            {
                coefficient = sum / dencity;
                Console.WriteLine($"{coefficient:F3}");
            }
            else
            {
                Console.WriteLine($"{sum:F3}");
            }
        }
    }
}
