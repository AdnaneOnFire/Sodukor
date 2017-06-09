using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public static class Solver
    {

        static int[] GetSpace(Soduko s, int x, int y)
        {
            var v = s[x, y];
            if (v != 0)
            {
                return new int[] { v };
            }
            return s.Range.Except(s.Line(x).Union(s.Row(y))).Distinct().ToArray();
        }

        public static int[,][] GetSoltionSpace(this Soduko soduko)
        {
            var s = soduko.Size;
            var solutionSpace = new int[s, s][];
            for (int i=0; i<s; i++)
                for(int j=0; j<s; j++)
                {
                    solutionSpace[i, j] = GetSpace(soduko, i, j);
                }
            return solutionSpace;
        }




    }
}
