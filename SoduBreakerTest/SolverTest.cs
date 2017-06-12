
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SoduBreaker.Tests
{
    [TestClass]
    public class SolverTest 
    {

        string data = "..2....74..8......6.3...12....8.1..3.....7.697...6921...6....3.8.41.........23...,912635874458712396673984125269851743381247569745369218126598437834176952597423681,";
        Soduko soduko;


        [TestInitialize]
        public void Setup()
        {
            int[,] pb;
            int[,] sol;
            ProblemGenerator.GetProblem(data, out pb, out sol);
            soduko = new Soduko(pb);
        }

        [TestMethod]
        public void ChooseNodeTest()
        {
            var choosed = soduko.ChooseNode();
            Assert.IsTrue(soduko[choosed.Item1, choosed.Item2] == 0);
        }

    }
}
