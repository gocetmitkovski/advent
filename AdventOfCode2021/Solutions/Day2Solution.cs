using System;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day2Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            var commands = input.Split('\n').ToList();
            var distance = 0;
            var depth2 = 0;
            var depth1 = 0;
            commands.ForEach(command =>
            {
                var splitted = command.Split();
                var commandVelosity = Convert.ToInt32(splitted[1]);
                switch (splitted[0])
                {
                    case "forward":
                        distance += commandVelosity;
                        depth2 += commandVelosity * depth1;
                        break;
                    case "up":
                        depth1 -= commandVelosity;
                        break;
                    case "down":
                        depth1 += commandVelosity;
                        break;
                    default:
                        break;
                }
            });

            Console.WriteLine($"{distance * depth1} and {distance * depth2}");

        }
    }
}
