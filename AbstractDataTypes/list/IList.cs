﻿namespace AbstractDataTypes.list;

public interface IList<T>
{
    void Add(T element);
    void Insert(int index, T element);

    T this[int index] { get; set; }

    void RemoveAt(int index);
    bool Remove(T element);

    int Count { get; }

    bool Contains(T element);

    void Clear();
}