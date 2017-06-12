
namespace ISoduBreaker
{
    public interface ISoduko
    {
        int[] Line(int x);
        int[] Row(int y);
        bool AreLinesValid();
        bool AreRowsValid();
        bool IsSodukoFilled();
        EnumHelper.State Evaluate();
    }
}
