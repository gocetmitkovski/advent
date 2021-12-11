using System;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day1Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            var numbers = input.Split('\n').Select(w => Convert.ToInt32(w)).ToList();
            var count1 = 0;
            var count2 = 0;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] < numbers[i + 1])
                {
                    count1++;
                }
            }

            for (int i = 0; i < numbers.Count - 3; i++)
            {
                if (numbers[i] + numbers[i + 1] + numbers[i + 2] < numbers[i + 1] + numbers[i + 2] + numbers[i + 3])
                {
                    count2++;
                }
            }

            Console.WriteLine($"{count1} and { count2}");
        }
    }
}
