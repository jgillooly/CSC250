using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC250.Sorting
{
    public class InsertionSort : ISortingStrategy
    {
        public int[] Sort(int[] ints)
        {
            bool inserted;
            for (int i = 1; i < ints.Length; i++)
            {
                inserted = false;
                int value = ints[i];
                for (int j = i; j > 0; j--)
                {
                    if (ints[j - 1] > value)
                    {
                        ints[j] = ints[j - 1];
                    }
                    else
                    {
                        ints[j] = value;
                        inserted = true;
                        break;
                    }
                }
                if (!inserted) ints[0] = value;
            }
            return ints;
        }
    }
}
