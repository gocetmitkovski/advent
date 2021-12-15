using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public class Day6Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            Console.WriteLine($"{GetLanternsAtXDay(input, 80)} and {GetLanternsAtXDay(input, 256)}");
        }

        private long GetLanternsAtXDay(string input, int days)
        {
            int targetDays = days;
            long[] counts = new long[9];
            foreach (int fish in input.Split(",").Select(int.Parse).ToList())
                counts[fish]++;

            for (int day = 0; day < targetDays; day++)
            {
                long zeroes = counts[0];
                for (int i = 1; i <= 8; i++)
                {
                    counts[i - 1] = counts[i];

                }
                counts[6] += zeroes;
                counts[8] = zeroes;
            }

            return counts.Sum();
        }
    }
}
