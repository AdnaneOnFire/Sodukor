using System;
using System.Collections.Generic;
using System.IO;

namespace SoduBreaker
{
    public static class ProblemGenerator
    {

        private static int Convert(char s)
        {
            if (s == '.')
            {
                return 0;
            }
            return int.Parse(s.ToString());
        }

        public static List<Tuple<int[,], int[,]>> GetProblems(string path)
        {
            var pbs = new List<Tuple<int[,], int[,]>>();
            var lines = File.ReadAllLines(path);
            int[,] pb;
            int[,] sol;
            foreach (var line in lines)
            {
                GetProblem(line, out pb, out sol);
                pbs.Add(new Tuple<int[,], int[,]>(pb, sol));
            }
            return pbs;
        }

        public static void GetProblem(string source, out int[,] problem, out int[,] solution)
        {
            var pb_sl = source.Split(',');
            var pb = pb_sl[0];
            var sl = pb_sl[1];
            var l = (int)Math.Sqrt(pb.Length);
            problem = new int[l, l];
            solution = new int[l, l];
            for (int i = 0; i < pb.Length; i++)
            {
                problem[i / l, i % l] = Convert(pb[i]);
            }
            for (int i = 0; i < pb.Length; i++)
            {
                solution[i / l, i % l] = Convert(sl[i]);
            }
        }

    }
}
