using System;
using Xunit;
using AbstractDataTypes.Sorting;

namespace AbstractDataTypes.Tests;

public class SortingTests
{
    private static void AssertSorted<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 1; i < arr.Length; i++)
            Assert.True(arr[i - 1].CompareTo(arr[i]) <= 0, "Array is not sorted");
    }

    [Theory]
    [InlineData(new int[] { })]
    [InlineData(new int[] { 1 })]
    [InlineData(new int[] { 2, 1 })]
    [InlineData(new int[] { 5, 3, 8, 1, 2, 9, 7 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 2, 3, 2, 1, 4, 1 })]
    public void QuickSort_Various(int[] input)
    {
        var sorter = new QuickSort<int>();
        var arr = (int[])input.Clone();
        sorter.Sort(arr);
        AssertSorted(arr);
    }

    [Theory]
    [InlineData(new int[] { })]
    [InlineData(new int[] { 1 })]
    [InlineData(new int[] { 2, 1 })]
    [InlineData(new int[] { 5, 3, 8, 1, 2, 9, 7 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 2, 3, 2, 1, 4, 1 })]
    public void MergeSort_Various(int[] input)
    {
        var sorter = new MergeSort<int>();
        var arr = (int[])input.Clone();
        sorter.Sort(arr);
        AssertSorted(arr);
    }

    [Theory]
    [InlineData(new int[] { })]
    [InlineData(new int[] { 1 })]
    [InlineData(new int[] { 2, 1 })]
    [InlineData(new int[] { 5, 3, 8, 1, 2, 9, 7 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 2, 3, 2, 1, 4, 1 })]
    public void InsertionSort_Various(int[] input)
    {
        var sorter = new InsertionSort<int>();
        var arr = (int[])input.Clone();
        sorter.Sort(arr);
        AssertSorted(arr);
    }

    [Theory]
    [InlineData(new int[] { })]
    [InlineData(new int[] { 1 })]
    [InlineData(new int[] { 2, 1 })]
    [InlineData(new int[] { 5, 3, 8, 1, 2, 9, 7 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 2, 3, 2, 1, 4, 1 })]
    public void BubbleSort_Various(int[] input)
    {
        var sorter = new BubbleSort<int>();
        var arr = (int[])input.Clone();
        sorter.Sort(arr);
        AssertSorted(arr);
    }
}
