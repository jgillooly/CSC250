using CSC250;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    [TestClass]
    public class QueensTesting
    {
        [TestMethod]
        public void testLeftDiag()
        {
            int[,] board = { { 1, 0 }, { 0, 1 } };
            Queens.currentn = 2;
            bool check = Queens.CheckPosition(board, 1, 1);
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void testRightDiag()
        {
            int[,] board = { { 0, 1 }, { 1, 0 } };
            Queens.currentn = 2;
            bool check = Queens.CheckPosition(board, 1, 0);
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void TestFive()
        {
            Queens.FindSolutions(5);
            Assert.IsTrue(Queens.solutions.Count == 10);
        }

        [TestMethod]
        public void TestSix()
        {
            Queens.FindSolutions(6);
            Assert.IsTrue(Queens.solutions.Count == 4);
        }

        [TestMethod]
        public void TestNine()
        {
            Queens.FindSolutions(9);
            Assert.IsTrue(Queens.solutions.Count == 352);
        }
    }
}
