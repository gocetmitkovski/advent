using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class AdventResolver
    {
        public string Input;
        public ISolution Solution { get; set; }

        public void ShowResult()
        {
            Solution?.PrintSolution(Input);
        }
    }
}
