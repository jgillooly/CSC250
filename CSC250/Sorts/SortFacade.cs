using CSC250.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC250.Sorts
{
    internal class SortFacade
    {
        public static int[] sortInts(int[] ints)
        {
            Context context = new Context();
            ISortingStrategy strategy = ints.Length <= 1000 ? new BubbleSort() : new InsertionSort();
            context.setStrategy(strategy);
            ints = context.sortInts(ints);
            return ints;
        }
    }
}
