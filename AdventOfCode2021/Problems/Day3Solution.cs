using System;
using System.Linq;

namespace AdventOfCode2021.Problems
{
    public class Day3Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            var binaryCodes = input.Split('\n').ToList();
            var totalCodes = binaryCodes.Count;
            var mostCommonBits = new int[12];
            var mostUncommonBits = new int[12];

            binaryCodes.ForEach(code =>
            {
                code = code.Trim();
                for (int i = 0; i < code.Length; i++)
                {
                    if (code[i] == '1')
                    {
                        mostCommonBits[i]++;
                    }
                }
            });

            var gammaRateBinary = string.Join("", mostCommonBits.Select((w, i) =>
            {
                if (w > totalCodes / 2)
                {
                    mostUncommonBits[i] = 0;
                    return 1;
                }
                mostUncommonBits[i] = 1;
                return 0;
            }).ToArray());

            var gammaRate = Convert.ToInt16(gammaRateBinary, 2);
            var epsilonRate = Convert.ToInt16(string.Join("", mostUncommonBits), 2);
            var lifeSupportRating = epsilonRate * gammaRate;

            Console.WriteLine($"Day 3 part 1: {lifeSupportRating}");
        }
    }
}
