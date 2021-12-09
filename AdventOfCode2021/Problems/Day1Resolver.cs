using System.IO;

namespace AdventOfCode2021.Problems
{
    public class Day1Resolver : AdventResolver
    {
        public Day1Resolver()
        {
            Input = Helper.GetInput("day1");
            Solution = new Day1Solution();
        }
    }
}
