using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSC250
{
    public static class Searches
    {
        public static int BinarySearch(int searchValue, int[] ints, int lowindex, int highindex)
        {
            if (lowindex > highindex || lowindex < 0 || lowindex > ints.Length - 1 || highindex > ints.Length - 1) { throw new RangeException(); }
            if (highindex - lowindex == 1 && ints[lowindex] != searchValue && ints[highindex] != searchValue) { return -1; }
            int middlevalueindex = highindex - ((highindex - lowindex) / 2);
            int middlevalue = ints[middlevalueindex];
            if (middlevalue == searchValue) { return middlevalueindex; }
            else if (middlevalue > searchValue)
            {
                int newlastindex = middlevalueindex - 1;
                return BinarySearch(searchValue, ints, lowindex, newlastindex);
            }
            else
            {
                int newfirstindex = middlevalueindex + 1;
                return BinarySearch(searchValue, ints, newfirstindex, highindex);
            }
        }
    }

    public class RangeException : Exception
    {

    }
}
