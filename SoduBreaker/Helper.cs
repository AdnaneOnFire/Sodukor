using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public static class Helper
    {
        public static void FillMtx(List<Tuple<int, int, int>> input, int[,] tab)
        {
            foreach (var t in input)
            {
                tab[t.Item1, t.Item2] = t.Item3;
            }
        }

        public static string PrettyPrint (this int[,] matrix)
        {
            var s = (int) Math.Sqrt(matrix.Length);
            StringBuilder str  =  new StringBuilder();
            for (int i = 0; i < s; i++)
            {
                for (int j=0; j<s; j++)
                {
                    str.Append(matrix[i, j]);
                }
                str.AppendLine();
            }
            return str.ToString();
        }

        public static string PrettyPrint(this int[,][] matrix)
        {
            var s = (int)Math.Sqrt(matrix.Length);
            var sb = new StringBuilder();
            for (int i = 0; i < s; i++)
            {
                {
                    for (int j = 0; j < s; j++)
                    {
                        sb.Append(matrix[i, j].PrettyPrint(s+1));
                    }
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        public static string PrettyPrint(this int[] array, int fill)
        {
            var sb = new StringBuilder();
            foreach (var elm in array)
            {
                sb.Append(elm);
                fill--;
            }
            sb.Append(' ',fill);
            return sb.ToString();
        }

        public static int[,] InvertMtx(int[,] matrix)
        {
            var l = (int)Math.Sqrt(matrix.Length);

            var inverted = new int[l, l];
            for (int x = 0; x < l; x++)
            {
                for (int y = 0; y < l; y++)
                {
                    inverted[x, y] = matrix[y, x];
                }
            }
            return inverted;
        }

        public static int[] Line(this int[,] m, int x, int _size)
        {
            var z = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                z[i] = m[x, i];
            }
            return z;
        }

        public static string SolutionSpaceString(this Soduko soduko)
        {
            return soduko.SoltionSpace().PrettyPrint();
        }
    }
}
