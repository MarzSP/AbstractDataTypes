using System;

namespace AbstractDataTypes.Sorting;

public class InsertionSort<T> : ISort<T> where T : IComparable<T>
{
    /** Sorts the array using insertion sort
     * TC: Best O(n) Worst O(n^2) */
    public void Sort(T[] array)
    {
        if (array is null) throw new ArgumentNullException(nameof(array));
        if (array.Length < 2) return;

        for (int i = 1; i < array.Length; i++)
        {
            T key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j].CompareTo(key) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}
