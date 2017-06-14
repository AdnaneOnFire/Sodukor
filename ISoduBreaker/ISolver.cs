

namespace ISoduBreaker
{
    public interface ISolver
    {
        ISoduko Solve(ISoduko problem, ref string depth);
    }
}
