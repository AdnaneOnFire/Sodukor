using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public class Soduko
    {

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

    }
}
