using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_RainAir
{
    class Program
    {
        static void Main(string[] args)
        {
            var flights = new Dictionary<string, List<int>>();
            var input = Console.ReadLine();

            while (input != "I believe I can fly!")
            {
                var tokens = input.Split(new[] { " ", "=" }, StringSplitOptions.RemoveEmptyEntries);
                var customerName = tokens[0];

                if (char.IsLetter(tokens[0][0]) && char.IsDigit(tokens[1][0]))
                {
                    if (!flights.ContainsKey(customerName))
                    {
                        flights[customerName] = new List<int>();
                    }
                    flights[customerName].AddRange(tokens.Skip(1).Select(int.Parse));
                }
                else
                {
                    var secondPassagerName = tokens[1];
                    flights[customerName] = new List<int>(flights[secondPassagerName]);
                }
                input = Console.ReadLine();
            }

            var sortedFlights = flights
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedFlights)
            {
                Console.WriteLine($"#{item.Key} ::: {string.Join(", ", item.Value.OrderBy(x => x))}");
            }
        }
    }
}
