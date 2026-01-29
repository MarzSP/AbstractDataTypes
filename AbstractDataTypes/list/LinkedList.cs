namespace AbstractDataTypes.list;
// Implementation of the ADT Linked List using a singly linked list
public class LinkedList<T> : IList<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? _head;
    private int _count;

    /**
     * Adds an element to the end of the linked list
     * TC: Best: O(1) Worst: O(n)
     */
    public void Add(T element)
    {
        Node newNode = new Node(element);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
        _count++;
    }

    /**
     * Inserts an element at the specified index
     * TC: Best: O(1) Worst: O(n)
     */
    public void Insert(int index, T element)
    {
        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException(nameof(index));

        Node newNode = new Node(element);
        if (index == 0)
        {
            newNode.Next = _head;
            _head = newNode;
        }
        else
        {
            Node current = _head!; // index > 0 so _head is not null
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        _count++;
    }

    /**
     * This is an indexer: which means you can access elements like array[index]
     * TC: Best: O(1) Worst: O(n)
     */
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = _head!;
            for (var i = 0; i < index; i++)
                current = current.Next!;

            return current.Value;
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = _head!;
            for (var i = 0; i < index; i++)
                current = current.Next!;

            current.Value = value;
        }
    }

    /**
     * Removes the element at the specified index
     * TC: Best: O(1) Worst: O(n)
     */
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            _head = _head?.Next;
        }
        else
        {
            Node current = _head!;
            for (var i = 0; i < index - 1; i++)
                current = current.Next!;

            // current is node before the one we want to remove
            current.Next = current.Next?.Next;
        }

        _count--;
    }

    /**
     * Removes the first occurrence of the specified element
     * TC: Best: O(1) Worst: O(n)
     */
    public bool Remove(T element)
    {
        Node? current = _head;
        Node? previous = null;

        EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        while (current != null)
        {
            if (comparer.Equals(current.Value, element))
            {
                if (previous == null)
                {
                    // removing head
                    _head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                _count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    /**
     * This property returns the number of elements in the linked list
     * This notation is shorthand for a getter method
     * TC: O(1)
     */
    public int Count => _count;

    /**
     * Checks if the linked list contains the specified element
     * TC: Best: O(1) Worst: O(n)
     */
    public bool Contains(T element)
    {
        Node? current = _head;
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        while (current != null)
        {
            if (comparer.Equals(current.Value, element))
                return true;
            current = current.Next;
        }

        return false;
    }

    /**
     * Clears the linked list
     * TC: O(1)
     */
    public void Clear()
    {
        _head = null;
        _count = 0;
    }
}