using System;

namespace AbstractDataTypes.Sorting;

public class MergeSort<T> : ISort<T> where T : IComparable<T>
{
    /** Sorts the array using merge sort
     * TC: Best O(n log n) Worst O(n log n) */
    public void Sort(T[] array)
    {
        if (array is null) throw new ArgumentNullException(nameof(array));
        if (array.Length < 2) return;
        T[] aux = new T[array.Length];
        MergeSortInternal(array, aux, 0, array.Length - 1);
    }

    private static void MergeSortInternal(T[] array, T[] aux, int lo, int hi)
    {
        if (lo >= hi) return;
        var mid = lo + (hi - lo) / 2;
        MergeSortInternal(array, aux, lo, mid);
        MergeSortInternal(array, aux, mid + 1, hi);
        Merge(array, aux, lo, mid, hi);
    }

    private static void Merge(T[] array, T[] aux, int lo, int mid, int hi)
    {
        int i = lo, j = mid + 1, k = lo;
        while (i <= mid && j <= hi)
        {
            if (array[i].CompareTo(array[j]) <= 0)
            {
                aux[k++] = array[i++];
            }
            else
            {
                aux[k++] = array[j++];
            }
        }
        while (i <= mid) aux[k++] = array[i++];
        while (j <= hi) aux[k++] = array[j++];
        for (var x = lo; x <= hi; x++) array[x] = aux[x];
    }
}
