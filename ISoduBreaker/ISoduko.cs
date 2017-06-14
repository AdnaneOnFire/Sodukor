
namespace ISoduBreaker
{
    public interface ISoduko
    {
        int[] Line(int x);
        int[] Row(int y);
        int[,] ProblemSet();
        bool AreLinesValid();
        bool AreRowsValid();
        bool IsSodukoFilled();
        EnumHelper.State Evaluate();
    }
}
