using System;

namespace AbstractDataTypes.Sorting;

public class QuickSort<T> : ISort<T> where T : IComparable<T>
{
    /** Sorts the array using quicksort (last-element pivot)
     * TC: Best O(n log n) Worst O(n^2) */
    public void Sort(T[] array)
    {
        if (array is null) throw new ArgumentNullException(nameof(array));
        if (array.Length < 2) return;
        Quick(array, 0, array.Length - 1);
    }

    /** Recursively sorts the subarray between lo and hi using quicksort
     * TC: Best O(n log n) Worst O(n^2) */
    private void Quick(T[] array, int lo, int hi)
    {
        if (lo >= hi) return;
        int p = Partition(array, lo, hi);
        Quick(array, lo, p - 1);
        Quick(array, p + 1, hi);
    }

    /** Partitions the array around the pivot (last element) and returns pivot index
     * TC: Best O(n) Worst O(n) */
    private int Partition(T[] array, int lo, int hi)
    {
        T pivot = array[hi];
        int i = lo;
        for (int j = lo; j < hi; j++)
        {
            if (array[j].CompareTo(pivot) <= 0)
            {
                Swap(array, i, j);
                i++;
            }
        }
        Swap(array, i, hi);
        return i;
    }

    /** Swaps two elements in the array
     * TC: Best O(1) Worst O(1) */
    private static void Swap(T[] array, int i, int j)
    {
        T tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}
