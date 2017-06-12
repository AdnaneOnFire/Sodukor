using System.Collections.Generic;
using System.Linq;

using ISoduBreaker;

namespace SoduBreaker
{
    public class SodukoNode : Soduko , ISodukoNode
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public int CurrentValue { get; set; }
        public List<int> ExploredValues { get; }
        public int[] PossibleValues { get; }

        public bool IsCompletlyExplored
        {
            get {return !PossibleValues.Except(ExploredValues).Any(); }
        }

        public SodukoNode(int[,] soduko, int x, int y) : base(soduko)
        {
            X = x;
            Y = y;
            PossibleValues = this.SolutionSpace(x, y);
            ExploredValues = new List<int>();
        }

        public void TryNextValue()
        {
            CurrentValue = PossibleValues.Except(ExploredValues).First();
            ExploredValues.Add(CurrentValue);
            Matrix[X, Y] = CurrentValue;
            InvertedMatrix[Y, X] = CurrentValue;
        }



        //public void UpdateNode(int exploredValue, )
    }
}
