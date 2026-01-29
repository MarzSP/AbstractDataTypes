namespace AbstractDataTypes.Sorting;

public interface ISort<T>
{
    /**
     * Sorts the given array in ascending order
     * TC: Depends on implementation
     */
    void Sort(T[] array);
}