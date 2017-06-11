
using NUnit.Framework;

namespace SoduBreaker.Tests
{
    [TestFixture]
    public class SolverTest 
    {

        string data = "..2....74..8......6.3...12....8.1..3.....7.697...6921...6....3.8.41.........23...,912635874458712396673984125269851743381247569745369218126598437834176952597423681,";
        Soduko soduko;


        [SetUp]
        public void Setup()
        {
            int[,] pb;
            int[,] sol;
            ProblemGenerator.GetProblem(data, out pb, out sol);
            soduko = new Soduko(pb);
        }

        [Test]
        public void ChooseNodeTest()
        {
            var choosed = soduko.ChooseNode();
            Assert.True(soduko.SolutionSpace(choosed.Item1, choosed.Item2).Length > 1);
        }

    }
}
