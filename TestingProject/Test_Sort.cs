using CSC250;

namespace TestingProject
{
    [TestClass]
    public class Test_Sort
    {
        [TestMethod]
        public void InsertionHappyPath()
        {
            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };

            var output = Sorts.InsertionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        public void InsertionNegativePath()
        {
            int[] initial = { 5, 3, 4, 1, 2, -1 };
            int[] expected = { -1, 1, 2, 3, 4, 5 };

            var output = Sorts.InsertionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        public void InsertionDuplicatePath()
        {
            int[] initial = { 5, 3, 4, 1, 2, 1 };
            int[] expected = { 1, 1, 2, 3, 4, 5 };

            var output = Sorts.InsertionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        public void InsertionSinglePath()
        {
            int[] initial = { 1 };
            int[] expected = { 1 };

            var output = Sorts.InsertionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        public void SelectionHappyPath()
        {
            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };

            var output = Sorts.SelectionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        public void SelectionNegativePath()
        {
            int[] initial = { 5, 3, 4, 1, 2, -1 };
            int[] expected = { -1, 1, 2, 3, 4, 5 };

            var output = Sorts.SelectionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        public void SelectionDuplicatePath()
        {
            int[] initial = { 5, 3, 4, 1, 2, 1 };
            int[] expected = { 1, 1, 2, 3, 4, 5 };

            var output = Sorts.SelectionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        public void SelectionSinglePath()
        {
            int[] initial = { 1 };
            int[] expected = { 1 };

            var output = Sorts.SelectionSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InsertionSadpath()
        {
            int[]? initial = null;
            Sorts.InsertionSort(initial);
     

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SelectionSadpath()
        {
            int[]? initial = null;
            Sorts.SelectionSort(initial);


        }

        [TestMethod]
        public void SwapHappyPath()
        {
            int[] initial = { 1, 2 };
            int[] expected = { 2, 1 };

            Sorts.Swap(ref initial, 0, 1);
            Assert.IsTrue(expected.SequenceEqual(initial));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SwapSadpath()
        {
            int[] initial = null;
            Sorts.Swap(ref initial, 0, 1);
        }
    }
}