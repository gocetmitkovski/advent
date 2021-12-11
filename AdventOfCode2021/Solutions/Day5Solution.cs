using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Solutions
{
    class Day5Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            var segments = input.Split("\r\n").ToList();

            Console.WriteLine($"{EvaluatePoints(segments, true)} and {EvaluatePoints(segments, false)}");
        }

        private int EvaluatePoints(List<string> segments, bool isPart1)
        {
            Dictionary<(int, int), int> plate = new Dictionary<(int, int), int>();

            segments.ForEach(segment =>
            {
                var coordinates = Regex.Split(segment, @"[^\d]+").Select(int.Parse).ToArray();
                int x1 = coordinates[0];
                int y1 = coordinates[1];
                int x2 = coordinates[2];
                int y2 = coordinates[3];

                int xDifferential = 0;
                int yDifferential = 0;
                if (x1 > x2) xDifferential = -1;
                if (x1 < x2) xDifferential = 1;
                if (y1 > y2) yDifferential = -1;
                if (y1 < y2) yDifferential = 1;

                if (isPart1 && xDifferential != 0 && yDifferential != 0) return;
                int currentX = x1;
                int currentY = y1;

                while (true)
                {
                    if (!plate.ContainsKey((currentX, currentY)))
                    {
                        plate[(currentX, currentY)] = 0;
                    }
                    plate[(currentX, currentY)]++;
                    if (StopPointCondition(currentX, currentY, x2, y2)) break;
                    currentX += xDifferential;
                    currentY += yDifferential;
                } 
            });

            return plate.Count(w => w.Value > 1);
        }
        private bool StopPointCondition(int x1, int y1, int x2, int y2)
        {
            return x1 == x2 && y1 == y2;
        }
    }
}
