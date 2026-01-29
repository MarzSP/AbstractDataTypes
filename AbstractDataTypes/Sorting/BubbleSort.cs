namespace AbstractDataTypes.Sorting;

public class BubbleSort<T> : ISort<T> where T : IComparable<T>
{
    /** Sorts the array by repeatedly swapping adjacent elements
     * TC: Best O(n) Worst O(n^2) */
    public void Sort(T[] array)
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));

        if (array.Length < 2)
            return;

        bool swapped;

        for (var i = 0; i < array.Length - 1; i++)
        {
            swapped = false;

            for (var j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                    swapped = true;
                }
            }

            if (!swapped)
                return;
        }
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