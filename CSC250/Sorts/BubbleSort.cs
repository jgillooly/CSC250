using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC250.Sorting
{
    public class BubbleSort : ISortingStrategy
    {
        public int[] Sort(int[] ints)
        {
            //perform until notified of no changes
            bool changed = false;
            do
            {
                //perfom a bubble on data and recieve if any changes were made
                changed = Bubble(ref ints);
            }
            while (changed);

            //return the sorted index
            return ints;
        }

        private bool Bubble(ref int[] ints)
        {
            bool changed = false;

            for (int i = 0; i < ints.Length - 1; i++)
            {
                //compare the current index and it's neighbor
                if (ints[i] > ints[i + 1])
                {
                    //swap if necessary
                    Swap(ref ints, i, i + 1);
                    //update the changed variable to reflect
                    changed = true;
                }
            }

            return changed;

        }

        private void Swap(ref int[] array, int indexa, int indexb)
        {
            //store placeholder number
            int firstNumber = array[indexa];
            //set first index to second index's value
            array[indexa] = array[indexb];
            //set second index to stored value from first index
            array[indexb] = firstNumber;
        }
    }
}
