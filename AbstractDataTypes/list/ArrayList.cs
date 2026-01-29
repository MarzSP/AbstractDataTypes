namespace AbstractDataTypes.list;

using System;
using System.Collections.Generic;

// Implementation of the ADT ArrayList using a dynamic array with the IList<T> interface
public class ArrayList<T> : IList<T>
{
    private T[] _elements = new T[DefaultCapacity];
    private int _size;
    private const int DefaultCapacity = 10;

    /** Adds an element to the end of the list
      TC: O(1) amortized. Best case O(1), worst case O(n) when resizing */
    public void Add(T element)
    {
        EnsureCapacity(_size + 1);
        _elements[_size++] = element;
    }

    /**
     * Inserts an element at the specified index
     * TC: O(n) in the worst case due to shifting elements
     */
    public void Insert(int index, T element)
    {
        if (index < 0 || index > _size) throw new ArgumentOutOfRangeException(nameof(index));
        EnsureCapacity(_size + 1);
        if (index < _size)
            Array.Copy(_elements, index, _elements, index + 1, _size - index);
        _elements[index] = element;
        _size++;
    }

    /** Gets or sets the element at the specified index
     * TC: O(1)
     */
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index));
            return _elements[index];
        }
        set
        {
            if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index));
            _elements[index] = value;
        }
    }

    /**
     * Removes the element at the specified index
     * TC: O(n) in the worst case due to shifting elements
     */
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index));
        var move = _size - index - 1;
        if (move > 0)
            Array.Copy(_elements, index + 1, _elements, index, move);
        _elements[--_size] = default!;
    }

    /**
     * Removes the first occurrence of the specified element
     * TC: O(n) due to searching for the element
     */
    public bool Remove(T element)
    {
        var index = IndexOf(element);
        if (index < 0) return false;
        RemoveAt(index);
        return true;
    }

    /** Gets the number of elements in the list
     * TC: O(1)
     * C# expression-bodied property - shorthand for simple properties
     */
    public int Count => _size;

    /**
     * Checks if the list contains the specified element
     * TC: O(n) due to searching for the element
     */
    public bool Contains(T element)
    {
        return IndexOf(element) >= 0;
    }

    /**
     * IndexOf helper method to find the index of an element
     * TC: O(n)
     * Var because the type is inferred by the compiler
     */
    private int IndexOf(T element)
    {
        var comparer = EqualityComparer<T>.Default;
        for (var i = 0; i < _size; i++)
            if (comparer.Equals(_elements[i], element))
                return i;
        return -1;
    }

    /**
     * Clears the list
     * TC: O(n) to reset all elements to default
     */
    public void Clear()
    {
        Array.Clear(_elements, 0, _size);
        _size = 0;
    }

    /**
     *  Checks and ensures the internal array has enough capacity. If not, it resizes the array.
     * TC: O(n) when resizing, O(1) otherwise
     */
    private void EnsureCapacity(int min)
    {
        if (_elements.Length >= min) return;
        var newCapacity = _elements.Length == 0 ? DefaultCapacity : _elements.Length * 2;
        if (newCapacity < min) newCapacity = min;
        Array.Resize(ref _elements, newCapacity);
    }
}