using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC250.Sorting
{
    public class Context
    {
        private ISortingStrategy strategy;

        public void setStrategy(ISortingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int[] sortInts(int[] ints)
        {
            return strategy.Sort(ints);
        }
    }
}
