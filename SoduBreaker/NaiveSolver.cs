using ISoduBreaker;


namespace SoduBreaker
{
    public class NaiveSolver : ISolver
    {
        public ISoduko Solve(ISoduko problem, ref string depth)
        {
            return NaiveSolverHelper.Solve((Soduko) problem, ref depth);
        }
    }
}
