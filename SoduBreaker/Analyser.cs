using System;
using System.Collections.Generic;

namespace SoduBreaker
{
    public static class Analyser
    {

        public static List<Tuple<int[,], int[,]>> testData;

        public static void Init()
        {
            testData = ProblemGenerator.GetProblems("Ressource/Problems.txt");
        }

        public static void Publish()
        {
            Init();
            var naiveSolver = new NaiveSolver();
            int i=0;
            foreach (var pb_sol in testData)
            {
                i++;
                var sodukoP = new Soduko(pb_sol.Item1);
                Console.WriteLine(string.Format("Problem {0}:\n{1}", i, sodukoP.Matrix.PrettyPrint()));
                var depth = "";
                var sodukoS = naiveSolver.Solve(sodukoP, ref depth).ProblemSet();
                var solution = new Soduko(pb_sol.Item2).ProblemSet();
                var solutionOk = sodukoS.AssertEqual(solution);
                Console.WriteLine(string.Format("\n : Solution :\n{0}\nDepth : {1}\n",sodukoS.PrettyPrint(), depth));
            }
        }

    }
}
