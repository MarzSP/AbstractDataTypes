using System;
using System.Collections.Generic;

namespace AbstractDataTypes.list;

public class SortedList<T> : IList<T>
{
    private readonly List<T> _items;
    private readonly IComparer<T> _comparer;

    /** Creates an empty SortedList using the default comparer
     * TC: Best: O(1) Worst: O(1) */
    public SortedList() : this(null)
    {
    }

    /** Creates an empty SortedList using the provided comparer
     * TC: Best: O(1) Worst: O(1) */
    public SortedList(IComparer<T>? comparer)
    {
        _comparer = comparer ?? Comparer<T>.Default;
        _items = new List<T>();
    }

    /** Adds an element while keeping the list sorted (inserts at proper index)
     * TC: Best: O(1) Worst: O(n) */
    public void Add(T element)
    {
        var idx = _items.BinarySearch(element, _comparer);
        if (idx < 0) idx = ~idx;
        _items.Insert(idx, element);
    }

    /** Inserts an element; for SortedList the index parameter is ignored and element is inserted in its sorted position.
     * TC: Best: O(1) Worst: O(n) */
    public void Insert(int index, T element)
    {
        // Validate index range to match IList contract, but still insert by value
        if (index < 0 || index > _items.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        Add(element);
    }

    /** Gets or sets the element at the specified index. Setting reinserts the value to keep order.
     * TC: Best: O(1) Worst: O(n) */
    public T this[int index]
    {
        get => _items[index];
        set
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Remove the item at index and re-insert the new value in sorted position
            _items.RemoveAt(index);
            Add(value);
        }
    }

    /** Removes the element at the given index
     * TC: Best: O(1) Worst: O(n) */
    public void RemoveAt(int index)
    {
        _items.RemoveAt(index);
    }

    /** Removes the first occurrence of element (if present)
     * TC: Best: O(1) Worst: O(n) */
    public bool Remove(T element)
    {
        var idx = _items.BinarySearch(element, _comparer);
        if (idx < 0) return false;
        _items.RemoveAt(idx);
        return true;
    }

    /** Number of elements in the list
     * TC: Best: O(1) Worst: O(1) */
    public int Count => _items.Count;

    /** Returns true if element is present (uses binary search)
     * TC: Best: O(1) Worst: O(log n) */
    public bool Contains(T element)
    {
        return _items.BinarySearch(element, _comparer) >= 0;
    }

    /** Clears the list
     * TC: Best: O(1) Worst: O(n) */
    public void Clear()
    {
        _items.Clear();
    }
}