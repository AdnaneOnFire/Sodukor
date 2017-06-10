using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public static class Solver
    {

        public static int[] SolutionSpace(this Soduko s, int x, int y)
        {
            var v = s[x, y];
            if (v != 0)
            {
                return new int[] { v };
            }
            return s.Range.Except(s.Line(x).Union(s.Row(y))).Distinct().ToArray();
        }

        public static int[,][] SoltionSpace(this Soduko soduko)
        {
            var s = soduko.Size;
            var solutionSpace = new int[s, s][];
            for (int i = 0; i < s; i++)
                for (int j = 0; j < s; j++)
                {
                    solutionSpace[i, j] = soduko.SolutionSpace(i, j);
                }
            return solutionSpace;
        }


        public static void Solve(Soduko problem, int depth)
        {
            var tmpSolution = new Soduko(problem.Matrix);
            var solSpace = tmpSolution.SoltionSpace();
            var size = problem.Size;
            int currentDepth = 0;
            while (currentDepth < depth)
            {
                if (!Simplify(ref tmpSolution))
                    break;
                currentDepth++;
            }
            return;
        }

        public static int[,][] Reduce(this Soduko problem)
        {
            var reducedProblem = problem;
            int i = problem.Size * problem.Size;
            while (i>0 && Simplify(ref reducedProblem))
            {
                i--;
            }
            return reducedProblem.SoltionSpace();
        }

        public static bool Simplify(ref Soduko problem)
        {
            var solSpace = problem.SoltionSpace();
            var simplified = false;
            for (int i = 0; i < problem.Size; i++)
                for (int j = 0; j < problem.Size; j++)
                {
                    if (solSpace[i, j].Length == 1)
                    {
                        problem[i, j] = solSpace[i, j][0];
                        simplified = true;
                    }
                }
            return simplified;
        }

        public static Soduko Solve(ref Soduko problem)
        {

            var history = new LinkedList<SodukoNode>();

            //simplify
            //If ok return solution
            //Choose a node
            //ExploreNode
            //simplify
            //If ok return solution
            //if incomplete explore childe node
            //if nok explore parent node with new value






            return null;
        }




    }
}
