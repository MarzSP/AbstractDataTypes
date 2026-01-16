namespace AbstractDataTypes.list;

using System;
using System.Collections.Generic;

public class ArrayList<T> : IList<T>
{
    private T[] _elements = new T[DefaultCapacity];
    private int _size;
    private const int DefaultCapacity = 10;

    public void Add(T element)
    {
        EnsureCapacity(_size + 1);
        _elements[_size++] = element;
    }

    public void Insert(int index, T element)
    {
        if (index < 0 || index > _size) throw new ArgumentOutOfRangeException(nameof(index));
        EnsureCapacity(_size + 1);
        if (index < _size)
            Array.Copy(_elements, index, _elements, index + 1, _size - index);
        _elements[index] = element;
        _size++;
    }

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

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index));
        int move = _size - index - 1;
        if (move > 0)
            Array.Copy(_elements, index + 1, _elements, index, move);
        _elements[--_size] = default!;
    }

    public bool Remove(T element)
    {
        int index = IndexOf(element);
        if (index < 0) return false;
        RemoveAt(index);
        return true;

    }

    public int Count => _size;

    public bool Contains(T element)
    {
        return IndexOf(element) >= 0;
    }

    private int IndexOf(T element)
    {
        var comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < _size; i++)
            if (comparer.Equals(_elements[i], element)) return i;
        return -1;
    }

    public void Clear()
    {
        Array.Clear(_elements, 0, _size);
        _size = 0;
    }


    private void EnsureCapacity(int min)
    {
        if (_elements.Length >= min) return;
        int newCapacity = _elements.Length == 0 ? DefaultCapacity : _elements.Length * 2;
        if (newCapacity < min) newCapacity = min;
        Array.Resize(ref _elements, newCapacity);
    }
}