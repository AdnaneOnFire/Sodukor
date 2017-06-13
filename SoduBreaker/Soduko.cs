using ISoduBreaker;
using System;
using System.Linq;

namespace SoduBreaker
{
    public class Soduko : ISoduko
    {


        private int[,] matrix;
        private int[,] invertedMatrix;
        private int[] RowBuffer { get; }

        public int[,] Matrix
        {
            get { return matrix; }
            set
            {
                if (matrix != value)
                {
                    matrix = value;
                    invertedMatrix = matrix.InvertMtx();
                }
            }
        }
        public int[,] InvertedMatrix
        {
            get { return invertedMatrix; }
            set
            {
                if (invertedMatrix != value)
                {
                    invertedMatrix = value;
                    matrix = invertedMatrix.InvertMtx();
                }
            }
        }
        public int Size { get; }
        public int Grid { get; }
        public int CellesNumber { get; }
        public int[] Range { get; }

        public Soduko(int[,] soduko)
        {
            matrix = soduko;
            invertedMatrix = Helper.InvertMtx(soduko);
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
            return InvertedMatrix.Line(y, Size);
        }

        public EnumHelper.State Evaluate()
        {
            var filled = IsSodukoFilled();
            var valid = AreLinesValid() && AreRowsValid();
            if (!valid)
                return EnumHelper.State.Failure;
            if (!filled)
                return EnumHelper.State.Unkown;
            return EnumHelper.State.Success;
        }

        public bool AreLinesValid()
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
