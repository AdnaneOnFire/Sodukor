using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public static class Program
    {


        static void Main()
        {
            var dataSet = @"..2....74..8......6.3...12....8.1..3.....7.697...6921...6....3.8.41.........23...,912635874458712396673984125269851743381247569745369218126598437834176952597423681";
            int[,] problem;
            int[,] solution;

            ProblemGenerator.GetProblem(dataSet, out problem, out solution);
            var sodukoP = new Soduko(problem);
            var sodukoS = new Soduko(solution);

            Console.WriteLine(string.Format("Soduko : \n{0} solution evaluation is {1}", sodukoP.Matrix.PrettyPrint(), Evaluator.Success(sodukoP)));
            Console.WriteLine(string.Format("Soduko Solution Space is: \n{0}", sodukoP.SolutionSpace()));
            Console.WriteLine(string.Format("Soduko : \n{0} solution evaluation is {1}", sodukoS.Matrix.PrettyPrint(), Evaluator.Success(sodukoS)));
            Console.WriteLine(string.Format("Soduko Solution Space is: \n{0}", sodukoS.SolutionSpace()));

            Console.Read();
        }
    }
}
