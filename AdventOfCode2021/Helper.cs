using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Helper
    {
        public static string GetInput(string day)
        {
            return File.ReadAllText($"../../../Inputs/{day}.txt");
        }

    }
}
