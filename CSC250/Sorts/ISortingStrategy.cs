using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC250.Sorting
{
    public interface ISortingStrategy
    {
        int[] Sort(int[] ints);
    }
}
