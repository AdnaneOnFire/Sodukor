using System;

namespace SoduBreaker
{
    public static class Program
    {


        static void Main()
        {
            //var dataSet = @"..2....74..8......6.3...12....8.1..3.....7.697...6921...6....3.8.41.........23...,912635874458712396673984125269851743381247569745369218126598437834176952597423681";
            //int[,] problem;
            //int[,] solution;


            //var naiveSolver = new NaiveSolver();
            //ProblemGenerator.GetProblem(dataSet, out problem, out solution);
            //var sodukoP = new Soduko(problem);
            //var sodukoS = new Soduko(solution);

            //Console.WriteLine(string.Format("Soduko : \n{0} solution evaluation is {1}", sodukoP.Matrix.PrettyPrint(), sodukoP.Evaluate()));
            //Console.WriteLine(string.Format("Soduko Solution Space is: \n{0}", sodukoP.SolutionSpaceString()));
            //Console.WriteLine(string.Format("Soduko Reduced Solution Space is: \n{0}", sodukoP.Reduce().PrettyPrint()));
            //Console.WriteLine(string.Format("Solution is: \n{0}", naiveSolver.Solve(sodukoP).ProblemSet().PrettyPrint()));

            //Console.WriteLine(string.Format("Soduko : \n{0} solution evaluation is {1}", sodukoS.Matrix.PrettyPrint(), sodukoS.Evaluate()));
            //Console.WriteLine(string.Format("Soduko Solution Space is: \n{0}", sodukoS.SolutionSpaceString()));
            //Console.WriteLine(string.Format("Soduko Reduced Solution Space is: \n{0}", sodukoS.Reduce().PrettyPrint()));
            //Console.WriteLine(string.Format("Solution is: \n{0}", naiveSolver.Solve(sodukoS).ProblemSet().PrettyPrint()));


            Analyser.Publish();
            Console.Read();
        }
    }
}
