using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    internal class Day7Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            var submarinesPositions = input.Split(",").Select(int.Parse);
            Console.WriteLine($"{CalculateShifts(submarinesPositions, true)} and {CalculateShifts(submarinesPositions, false)}");
        }

        private int CalculateShifts(IEnumerable<int> submarinesPositions, bool isPart1)
        {
            var maxPosition = submarinesPositions.Max();
            var minPosition = submarinesPositions.Min();

            Dictionary<int, int> sumPerPosition = new();

            for (int position = minPosition; position <= maxPosition; position++)
            {
                if (!submarinesPositions.Contains(position) && isPart1 || sumPerPosition.ContainsKey(position))
                {
                    continue;
                }

                sumPerPosition[position] = 0;
                foreach (var submarinePosition in submarinesPositions)
                {
                    var shifts = Math.Abs(submarinePosition - position);
                    sumPerPosition[position] += isPart1 ? shifts : shifts * (shifts + 1) / 2;
                }
            }

            return sumPerPosition.Values.Min();
        }
    }
}