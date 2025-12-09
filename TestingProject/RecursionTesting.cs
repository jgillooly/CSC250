using CSC250;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    [TestClass]
    public class RecursionTesting
    {
        [TestMethod]
        public void TestMerge()
        {
            int[] input1 = { 1, 3, 5 };
            int[] input2 = { 2, 4, 6 };
            int[] expected = { 1, 2, 3, 4, 5, 6 };
            var output = Sorts.Merge(input1 , input2);
            Assert.IsTrue(output.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestMergeDupe()
        {
            int[] input1 = { 1, 3, 5 };
            int[] input2 = { 1, 3, 5 };
            int[] expected = { 1, 1, 3, 3, 5, 5 };
            var output = Sorts.Merge(input1, input2);
            Assert.IsTrue(output.SequenceEqual(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMergeNull()
        {
            int[] input1 = { 1, 3, 5 };
            int[] input2 = null;
            int[] expected = { 1, 1, 3, 3, 5, 5 };
            var output = Sorts.Merge(input1, input2);
            Assert.IsTrue(output.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestMergeSort()
        {
            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };

            Sorts.MergeSort(ref initial);

            Assert.IsTrue(expected.SequenceEqual(initial));
        }

        [TestMethod]
        public void TestMergeSortDupe()
        {
            int[] initial = { 5, 3, 1, 4, 1, 2 };
            int[] expected = { 1, 1, 2, 3, 4, 5 };

            Sorts.MergeSort(ref initial);

            Assert.IsTrue(expected.SequenceEqual(initial));
        }



        [TestMethod]
        public void TestQuickSort()
        {
            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };


            Sorts.QuickSort(ref initial, 0, initial.Length - 1);

            Assert.IsTrue(expected.SequenceEqual(initial));
        }

        [TestMethod]
        public void TestQuickSortDupe()
        {
            int[] initial = { 5, 3, 1, 4, 1, 2 };
            int[] expected = { 1, 1, 2, 3, 4, 5 };

            Sorts.QuickSort(ref initial, 0, initial.Length - 1);

            Assert.IsTrue(expected.SequenceEqual(initial));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestQuickSortNull()
        {
            int[] initial = null;
            int[] expected = { 1, 2, 3, 4, 5 };


            Sorts.QuickSort(ref initial, 0, initial.Length - 1);

            Assert.IsTrue(expected.SequenceEqual(initial));
        }

        [TestMethod]
        public void TestGetPivotValue()
        {
            int[] ints = { 3, 1, 2 };
            int expected = 1;
            var output = Sorts.GetPivot(ref ints, 0, 2);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestPivotArrange()
        {
            int[] ints = { 3, 1, 2 };
            int[] expected = { 1, 2, 3 };
            var output = Sorts.GetPivot(ref ints, 0, 2);
            Assert.IsTrue(ints.SequenceEqual(expected));
        }
    }
}
