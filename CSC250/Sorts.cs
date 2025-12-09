using System.Runtime.Serialization.Formatters;

namespace CSC250
{
    public class Sorts
    {
        #region Basic Baby Stuff
        /// <summary>
        /// Sorts an array of integers using Bubblesort
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] ints)
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

        /// <summary>
        /// Sorts an array of integers using Insertionsort
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] ints)
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

        /// <summary>
        /// Sorts an array of integers using Selectionsort
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static int[] SelectionSort(int[] ints)
        {
            int selectedindex;
            for (int i = 0; i < ints.Length - 1; i++)
            {
                selectedindex = i;
                for (int j = i + 1; j < ints.Length; j++)
                {
                    if (ints[j] < ints[selectedindex]) selectedindex = j;
                }
                Swap(ref ints, selectedindex, i);
            }

            return ints;
        }

        /// <summary>
        /// Swaps two values in an integer array provided as a reference
        /// </summary>
        /// <param name="array"></param>
        /// <param name="indexa"></param>
        /// <param name="indexb"></param>
        public static void Swap(ref int[] array, int indexa, int indexb)
        {
            //store placeholder number
            int firstNumber = array[indexa];
            //set first index to second index's value
            array[indexa] = array[indexb];
            //set second index to stored value from first index
            array[indexb] = firstNumber;
        }

        /// <summary>
        /// moves the largest number in an integer array to the end
        /// </summary>
        /// <param name="ints">an integer array</param>
        /// <returns>true if any swaps were made, else false</returns>
        public static bool Bubble(ref int[] ints)
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
        #endregion

        public static int[] Merge(int[] ints1, int[] ints2)
        {
            int[] result = new int[ints1.Length + ints2.Length];
            int ints1index = 0, ints2index = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (ints1index < ints1.Length && ints2index < ints2.Length)
                {
                    if (ints1[ints1index] < ints2[ints2index] || ints1[ints1index] == ints2[ints2index])
                    {
                        result[i] = ints1[ints1index++];
                    }
                    else if (ints1[ints1index] > ints2[ints2index])
                    {
                        result[i] = ints2[ints2index++];
                    }
                }
                else
                {
                    if (ints1index == ints1.Length)
                    {
                        result[i] = ints2[ints2index++];
                    }
                    else if (ints2index == ints2.Length)
                    {
                        result[i] = ints1[ints1index++];
                    }
                }
            }

            return result;
        }

        public static void MergeSort(ref int[] ints)
        {
            if (ints.Length == 2)
            {
                int[] ints1 = { ints[0] };
                int[] ints2 = { ints[1] };
                ints = Merge(ints1, ints2);
            }
            else if (ints.Length == 1)
            {
                return;
            }
            else
            {
                int halfway = ints.Length / 2;
                int[] ints1 = new int[halfway];
                int[] ints2 = new int[ints.Length - halfway];

                Array.Copy(ints, ints1, halfway);
                Array.Copy(ints, halfway, ints2, 0, ints.Length - halfway);
                MergeSort(ref ints1);
                MergeSort(ref ints2);
                ints = Merge(ints1, ints2);
            }
        }

        public static void QuickSort(ref int[] ints, int startIndex, int endIndex)
        {
            if (endIndex == startIndex)
            {
                return;
            }
            else if (endIndex - startIndex == 1)
            {
                if (ints[startIndex] > ints[endIndex]) Swap(ref ints, startIndex, endIndex);
                return;
            }
            else
            {
                int pivot = GetPivot(ref ints, startIndex, endIndex);
                bool swapping = true;
                while (swapping)
                {
                    int leftIndex = -1;
                    for (int i = startIndex; i < pivot; i++)
                    {
                        if (ints[i] > ints[pivot])
                        {
                            leftIndex = i;
                            break;
                        }
                    }
                    if (leftIndex == -1) { leftIndex = pivot; swapping = false; }

                    int rightIndex = -1;
                    for (int i = endIndex; i > pivot; i--)
                    {
                        if (ints[i] < ints[pivot] || ints[i] == ints[pivot])
                        {
                            rightIndex = i;
                            break;
                        }
                    }
                    if (rightIndex == -1) { rightIndex = pivot; swapping = false; }
                    Swap(ref ints, leftIndex, rightIndex);
                    if (leftIndex == pivot) { pivot = rightIndex; }
                    else if (rightIndex == pivot) { pivot = leftIndex; }
                }

                QuickSort(ref ints, startIndex, pivot - 1);

                QuickSort(ref ints, pivot + 1, endIndex);
            }
        }

        public static int GetPivot(ref int[] ints, int startIndex, int endIndex)
        {
            int pivot = endIndex - (endIndex - startIndex) / 2;
            int[] values = new int[3];
            values[0] = ints[startIndex];
            values[1] = ints[pivot];
            values[2] = ints[endIndex];
            values = BubbleSort(values);

            ints[startIndex] = values[0];
            ints[pivot] = values[1];
            ints[endIndex] = values[2];

            return pivot;
        }
    }
}
