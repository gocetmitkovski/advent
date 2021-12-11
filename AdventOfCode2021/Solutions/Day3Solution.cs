using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day3Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            var binaryCodes = input.Split('\n').Select(w => w.Trim()).ToList();
            var totalCodes = binaryCodes.Count;
            var mostCommonBits = new int[12];
            var mostUncommonBits = new int[12];

            binaryCodes.ForEach(code =>
            {
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
                if (w >= totalCodes / 2)
                {
                    mostUncommonBits[i] = 0;
                    return 1;
                }
                mostUncommonBits[i] = 1;
                return 0;
            }).ToArray());

            var gammaRate = Convert.ToInt16(gammaRateBinary, 2);
            var epsilonRate = Convert.ToInt16(string.Join("", mostUncommonBits), 2);
            var oxygenRating = Convert.ToInt16(SegregateByBitRatio(binaryCodes, 0, true), 2);
            var co2Rating = Convert.ToInt16(SegregateByBitRatio(binaryCodes, 0, false), 2);

            var powerConsumption = epsilonRate * gammaRate;
            var lifeSupportRating = oxygenRating * co2Rating;

            Console.WriteLine($"{powerConsumption} and {lifeSupportRating}");
        }

        private string SegregateByBitRatio(List<string> codes, int count, bool isCommon)
        {
            while (codes.Count > 1)
            {
                return SegregateByBitRatio(codes.Where(c => c[count] == FindBitRatio(codes.Select(w => w[count]).ToList(), isCommon)).ToList(), ++count, isCommon);
            }

            return codes[0];
        }

        private char FindBitRatio(IEnumerable<char> bits, bool isCommon)
        {

            if (bits.Count(b => b == '1') >= bits.Count(b => b == '0'))
            {
                return isCommon ? '1' : '0';
            }

            return isCommon ? '0' : '1';
        }

    }
}
