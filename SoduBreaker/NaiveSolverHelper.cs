using ISoduBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public static class NaiveSolverHelper
    {

        public delegate int[,] Del(int[,][] t);

        public static int[] SolutionSpace(this Soduko s, int x, int y)
        {
            var v = s[x, y];
            if (v != 0)
            {
                return new int[] { v };
            }
            return s.Range.Except(s.Line(x).Union(s.Row(y))).Distinct().ToArray();
        }

        public static int[,][] SolutionSpace(this Soduko soduko)
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

        public static void SimpleSolve(Soduko problem, int depth)
        {
            var tmpSolution = new Soduko(problem.Matrix);
            var solSpace = tmpSolution.SolutionSpace();
            var size = tmpSolution.Size;
            int currentDepth = 0;
            while (currentDepth < depth)
            {
                if (!tmpSolution.Simplify())
                    break;
                currentDepth++;
            }
            return;
        }

        public static int[,][] Reduce(this Soduko problem)
        {
            var reducedProblem = problem;
            int i = problem.Size * problem.Size;
            while (i > 0 && reducedProblem.Simplify())
            {
                i--;
            }
            return reducedProblem.SolutionSpace();
        }

        public static bool Simplify(this Soduko problem)
        {
            var solSpace = problem.SolutionSpace();
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

        public static Soduko Explore(LinkedList<SodukoNode> history, ref string depth)
        {
            //simplify
            //If ok return solution
            //Choose a node
            //ExploreNode
            //simplify
            //If ok return solution
            //if incomplete explore childe node
            //if nok explore parent node with new value
            var x = history.Count != 0 ? history.Last().PossibleValues.Length : 0;
            depth += history.Count +"-"+x+ ",";
            history.Last().PrettyPrint();
            if (history.Count > 89)
            {
                throw new Exception("No fking way");
            }
            var node = history.Last();
            //Console.WriteLine(string.Format("Node  ({0},{1}) is completly explored ? : {2} \n{3}", node.X, node.Y, node.IsCompletlyExplored, node.PrettyPrint()));

            if (node.IsCompletlyExplored)
            {
                history.RemoveLast();
                return Explore(history, ref depth);
            }
            node.TryNextValue();
            //node.Simplify();
            var eval = node.Evaluate();
            if (eval == EnumHelper.State.Success)
                return node;
            if (eval == EnumHelper.State.Failure)
            {
                if (node.IsCompletlyExplored)
                {
                    //history.RemoveLast();
                    return Explore(history, ref depth);
                }
                return Explore(history, ref depth);
            }
            //Eval = Unkown
            //if (node.IsCompletlyExplored)
            //{
            var coordinates = ChooseNode(node);
            if (coordinates != null)
            {
                var newNode = new SodukoNode(node.Matrix, coordinates.Item1, coordinates.Item2);
                history.AddLast(newNode);

            }
            else if( coordinates == null)
            {
                //history.RemoveLast();
            }
            //}
            return Explore(history, ref depth);
        }

        public static Soduko Solve(Soduko p, ref string depth)
        {

            var problem = new Soduko(p);
            var history = new LinkedList<SodukoNode>();
            if (problem.Evaluate() == EnumHelper.State.Success)
                return problem;
            var coordinates = ChooseNode(problem);
            var node = new SodukoNode(problem.Matrix, coordinates.Item1, coordinates.Item2);
            history.AddLast(node);

            return Explore(history, ref depth);
        }

        public static Tuple<int, int> ChooseNode(this Soduko soduko)
        {
            var solutionSpace = soduko.SolutionSpace();
            var sorted = solutionSpace.InvertByLength();
            sorted[0] = new List<Tuple<int, int>>();
            var s1 = new List<Tuple<int, int>>();
            if (sorted[1] != null)
            {
                foreach (var elm in sorted[1])
                {
                    if (soduko[elm.Item1, elm.Item2] == 0)
                        s1.Add(elm);
                }
            }
            sorted[1] = s1;
            var candidates = sorted.FirstOrDefault(x => x.Count > 0);
            return candidates == null ? null : candidates[0];
        }

        public static List<Tuple<int, int>>[] InvertByLength(this int[,][] tab)
        {
            var s = (int)Math.Sqrt(tab.Length);
            var rep = new List<Tuple<int, int>>[s];
            for (int i = 0; i < s; i++)
            {
                rep[i] = new List<Tuple<int, int>>();
            }
            var t = new Tuple<int, int>(0, 0);
            for (int i = 0; i < s; i++)
                for (int j = 0; j < s; j++)
                {
                    t = new Tuple<int, int>(i, j);
                    rep[tab[i, j].Length].Add(t);
                }
            return rep;
        }

    }
}
