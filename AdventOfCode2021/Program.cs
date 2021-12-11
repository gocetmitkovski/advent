using AdventOfCode2021.Solutions;
using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var dailyResolutions = new List<AdventResolver>() {
                new Day1Resolver(),
                new Day2Resolver(),
                new Day3Resolver(),
                new Day4Resolver()
            };

            for (int i = 0; i < dailyResolutions.Count; i++)
            {
                Console.WriteLine($"==================== Day {i + 1} ====================");
                dailyResolutions[i].ShowResult();
                Console.WriteLine("\n");
            }

            Console.ReadLine();
        }

    }
}
