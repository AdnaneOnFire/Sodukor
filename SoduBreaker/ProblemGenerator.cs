using System;

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

        //..2....74..8......6.3...12....8.1..3.....7.697...6921...6....3.8.41.........23...,912635874458712396673984125269851743381247569745369218126598437834176952597423681,
        public static void GetProblem(string source, out int[,] problem, out int[,] solution)
        {
            var pb_sl = source.Split(',');
            var pb = pb_sl[0];
            var sl = pb_sl[1];
            var l = (int) Math.Sqrt(pb.Length);
            problem = new int[l, l];
            solution = new int[l, l];
            for (int i=0; i<pb.Length; i++)
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
