using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03_Raincast
{
    class Program
    {
        static void Main(string[] args)
        {
         
                string type = @"^Type: (Normal|Warning|Danger)$";
                string source = @"^Source: [A-Za-z0-9]+$";
                string forecast = @"^Forecast: ([^!.,?]+)$";

                var input = Console.ReadLine();
                List<string> output = new List<string>();
                bool haveType = false;
                bool haveSource = false;
                bool checkForDoubleType = true;


                while (input != "Davai Emo")
                {
                    var isType = Regex.IsMatch(input, type);
                    var isSource = Regex.IsMatch(input, source);
                    var isForecast = Regex.IsMatch(input, forecast);
                    if (isType && checkForDoubleType)
                    {
                        output.Add(input);
                        haveType = true;
                        checkForDoubleType = false;
                    }
                    if (isSource && haveType && !haveSource)
                    {
                        output.Add(input);
                        haveSource = true;
                    }
                    if (isForecast && haveSource)
                    {
                        output.Add(input);
                        haveSource = false;
                        haveType = false;
                        checkForDoubleType = true;
                    }
                    input = Console.ReadLine();
                }
                for (int i = 0; i < output.Count; i++)
                {
                    string typeToPrint;
                    string sourceToPrint;
                    string forecastToPrint;
                    if (output.Count % 3 == 0)
                    {
                        if (i % 3 == 0)
                        {
                            typeToPrint = output[i];
                            typeToPrint = typeToPrint.Substring(6);
                            Console.Write($"({typeToPrint})");
                        }
                        else if ((i % 3) + 1 == 2)
                        {
                            forecastToPrint = output[i + 1];
                            forecastToPrint = forecastToPrint.Substring(9);
                            Console.Write($"{forecastToPrint} ~");
                        }
                        else if ((i % 3) - 1 == 1)
                        {
                            sourceToPrint = output[i - 1];
                            sourceToPrint = sourceToPrint.Substring(8);
                            Console.Write($" {sourceToPrint}");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        if (output.Count - i == 2 && output.Count % 2 == 0)
                        {
                            break;
                        }
                        if (i % 3 == 0)
                        {
                            typeToPrint = output[i];
                            typeToPrint = typeToPrint.Substring(6);
                            Console.Write($"({typeToPrint})");
                        }
                        else if ((i % 3) + 1 == 2)
                        {
                            forecastToPrint = output[i + 1];
                            forecastToPrint = forecastToPrint.Substring(9);
                            Console.Write($"{forecastToPrint} ~");
                        }
                        else if ((i % 3) - 1 == 1)
                        {
                            sourceToPrint = output[i - 1];
                            sourceToPrint = sourceToPrint.Substring(8);
                            Console.Write($" {sourceToPrint}");
                            Console.WriteLine();
                        }
                    }
                }
            
        }
    }
}
