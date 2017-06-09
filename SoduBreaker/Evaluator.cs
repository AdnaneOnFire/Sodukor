using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public static class Evaluator
    {


        public static bool AreLinesValid(this Soduko soduko )
        {
            var s = soduko.Size;
            var row = soduko.RowBuffer;
            return AreLinesValid(soduko.Matrix, s, row);
        }

        public static bool AreRowsValid(this Soduko soduko)
        {
            var s = soduko.Size;
            var row = soduko.RowBuffer;
            return AreLinesValid(soduko.InvertedMatrix, s, row);
        }

        public static bool IsSodukoFilled(this Soduko soduko)
        {
            foreach (var elm in soduko.Matrix)
            {
                if (elm < 1 || elm > soduko.Size)
                    return false;
            }
            return true;
        }

        public static bool Success(this Soduko soduko)
        {
            return IsSodukoFilled(soduko) && AreLinesValid(soduko) && AreRowsValid(soduko);
        }

        #region private methods

        private static bool AreLinesValid(int[,] matrix, int s, int[] row)
        {
            for (int i = 0; i < s; i++)
            {
                Buffer.BlockCopy(matrix, i * s * 4, row, 0, s * 4);
                var distinct = row.Distinct().Count();
                if (distinct != s)
                    return false;
            }
            return true;
        }

        #endregion
    }
}
