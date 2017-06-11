using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public class Soduko
    {
        public enum State
        {
            Success,
            Failure,
            Unkown
        }

        public int[,] Matrix { get; set; }
        public int Size { get; set; }
        public int Grid { get; set; }
        public int CellesNumber { get; set; }
        public int[] RowBuffer { get; set; }
        public int[,] InvertedMatrix { get; set; }
        public int[] Range { get; set; }

        public Soduko(int[,] soduko)
        {
            Matrix = soduko;
            InvertedMatrix = Helper.InvertMtx(soduko);
            CellesNumber = Matrix.Length;
            Size = (int)Math.Sqrt(CellesNumber);
            Grid = (int)Math.Sqrt(Size);
            RowBuffer = new int[Size];
            Range = Enumerable.Range(1, Size).ToArray();
        }

        public int this[int x, int y]
        {
            get => Matrix[x, y];
            set => Matrix[x, y] = value;
        }

        public int[] Line(int x)
        {
            return Matrix.Line(x, Size);
        }

        public int[] Row(int y)
        {
            return InvertedMatrix.Line(y,Size);
        }

        public State Evaluate()
        {
            var filled = IsSodukoFilled();
            var valid = AreLinesValid() && AreRowsValid();
            if (!valid)
                return State.Failure;
            if (!filled)
                return State.Unkown;
            return State.Success;
        }

        public  bool AreLinesValid()
        {
            return AreLinesValid(Matrix, Size, RowBuffer);
        }

        public bool AreRowsValid()
        {
            return AreLinesValid(InvertedMatrix, Size, RowBuffer);
        }

        public bool IsSodukoFilled()
        {
            foreach (var elm in Matrix)
            {
                if (elm < 1 || elm > Size)
                    return false;
            }
            return true;
        }

        #region private methods

        private static bool AreLinesValid(int[,] matrix, int s, int[] row)
        {
            for (int i = 0; i < s; i++)
            {
                Buffer.BlockCopy(matrix, i * s * 4, row, 0, s * 4);
                var all = row.Where(x => x != 0).ToArray();
                var distinct = all.Distinct();              
                if (distinct.Count() != all.Length)
                    return false;
            }
            return true;
        }

        #endregion
    }
}
