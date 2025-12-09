using CSC250.Sorting;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    [TestClass]
    public class StrategyTesting
    {
        [TestMethod]
        public void TestBubbleStrategy()
        {
            CSC250.Sorting.Context context = new CSC250.Sorting.Context();

            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };
            CSC250.Sorting.ISortingStrategy strategy = new CSC250.Sorting.BubbleSort();
            context.setStrategy(strategy);
            int[] output = context.sortInts(initial);

            Assert.IsTrue(expected.SequenceEqual(output));

        }

        [TestMethod]
        public void TestInsertionStrategy()
        {
            CSC250.Sorting.Context context = new CSC250.Sorting.Context();

            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };
            CSC250.Sorting.ISortingStrategy strategy = new CSC250.Sorting.InsertionSort();
            context.setStrategy(strategy);
            int[] output = context.sortInts(initial);

            Assert.IsTrue(expected.SequenceEqual(output));

        }
    }
}
