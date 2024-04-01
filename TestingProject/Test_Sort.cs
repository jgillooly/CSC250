using CSC250;

namespace TestingProject
{
    [TestClass]
    public class Test_Sort
    {
        [TestMethod]
        public void HappyPath()
        {
            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };

            var output = Sorts.BubbleSort(initial);

            Assert.IsTrue(expected.SequenceEqual(output));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Sadpath()
        {
            int[]? initial = null;
            Sorts.BubbleSort(initial);
     

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

        [TestMethod]
        public void TestBubble()
        {
            int[] initial = { 5, 3, 4, 1, 2 };
            int[] expected = { 3, 4, 1, 2, 5 };

            Sorts.Bubble(ref initial);

            Assert.IsTrue(expected.SequenceEqual(initial));
        }
    }
}