using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoduBreaker
{
    public class Soduko
    {

        int[,] matrix;
        int[,] invertedMatrix;
        int size;
        int grid;
        int cellesNumber;
        int[] rowBuffer;
        int[] range;

        public int[,] Matrix { get => matrix; set => matrix = value; }
        public int Size { get => size; set => size = value; }
        public int Grid { get => grid; set => grid = value; }
        public int CellesNumber { get => cellesNumber; set => cellesNumber = value; }
        public int[] RowBuffer { get => rowBuffer; set => rowBuffer = value; }
        public int[,] InvertedMatrix { get => invertedMatrix; set => invertedMatrix = value; }
        public int[] Range { get => range; set => range = value; }

        public Soduko(int[,] soduko)
        {
            matrix = soduko;
            invertedMatrix = Helper.InvertMtx(soduko);
            cellesNumber = Matrix.Length;
            size = (int)Math.Sqrt(cellesNumber);
            grid = (int)Math.Sqrt(Size);
            rowBuffer = new int[Size];
            range = Enumerable.Range(1, size).ToArray();
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
