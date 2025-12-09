using CSC250;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    [TestClass]
    public class SearchTesting
    {
        [TestMethod]
        public void TestForSearch()
        {
            int[] ints = { 1, 2, 3, 4, 5 };
            int expected = 3;
            int index = Searches.BinarySearch(4, ints, 0, ints.Length - 1);
            Assert.AreEqual(expected, index);
        }

        [TestMethod]
        public void TestForSearchDupe()
        {
            int[] ints = { 1, 2, 2, 3, 4 };
            int expected = 2;
            int index = Searches.BinarySearch(2, ints, 0, ints.Length - 1);
            Assert.AreEqual(expected, index);
        }

        [TestMethod]
        public void NotFountTest()
        {
            int[] ints = { 1, 2, 3, 4, 5 };
            int expected = -1;
            int index = Searches.BinarySearch(10, ints, 0, ints.Length - 1);
            Assert.AreEqual(expected, index);
        }

        [TestMethod]
        public void NotFountTestNegative()
        {
            int[] ints = { 1, 2, 3, 4, 5 };
            int expected = -1;
            int index = Searches.BinarySearch(-10, ints, 0, ints.Length - 1);
            Assert.AreEqual(expected, index);
        }

        [TestMethod]
        [ExpectedException(typeof(RangeException))]
        public void BoundsExceptionTest()
        {
            int[] ints = { 1, 2, 3, 4 };
            int expected = -1;
            int index = Searches.BinarySearch(5, ints, 5, ints.Length - 1);
            Assert.AreEqual(expected, index);
        }

        [TestMethod]
        [ExpectedException(typeof(RangeException))]
        public void BoundsExceptionTestNegative()
        {
            int[] ints = { 1, 2, 3, 4 };
            int expected = -1;
            int index = Searches.BinarySearch(5, ints, -5, ints.Length - 1);
            Assert.AreEqual(expected, index);
        }

        [TestMethod]
        [ExpectedException (typeof(NullReferenceException))]
        public void NullExceptionTest()
        {
            int expected = -1;
            int index = Searches.BinarySearch(5, null, 5, 20);
            Assert.AreEqual(expected, index);
        }
    }
}
