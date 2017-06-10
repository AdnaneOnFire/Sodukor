using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public class SodukoNode : Soduko
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public int CurrentValue { get; set; }
        public int[] ExploredValues { get; set; }
        public int[] PossibleValues { get; }



        public SodukoNode(int[,] soduko, int x, int y) : base(soduko)
        {
            X = x;
            Y = y;
            PossibleValues = this.SolutionSpace(x, y);
        }



        //public void UpdateNode(int exploredValue, )
    }
}
