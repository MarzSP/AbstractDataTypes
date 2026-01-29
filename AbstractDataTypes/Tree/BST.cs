using System;
using System.Collections;
using System.Collections.Generic;

namespace AbstractDataTypes.Tree;

public class BST<T> : IEnumerable<T> where T : IComparable<T>
{
    private class Node
    {
        public T Key;
        public LinkedList<T> Values; // stores duplicates (BCL LinkedList)
        public Node? Left;
        public Node? Right;

        public Node(T value)
        {
            Key = value;
            Values = new LinkedList<T>();
            Values.AddLast(value);
            Left = null;
            Right = null;
        }
    }

    private Node? _root;
    private int _count; // total number of values stored (including duplicates)

    /** Adds a value to the BST. Duplicates are stored in an internal linked list on the node.
     * TC: Best O(1) Worst O(n) */
    public void Add(T value)
    {
        if (_root == null)
        {
            _root = new Node(value);
            _count = 1;
            return;
        }

        Node current = _root;
        while (true)
        {
            int cmp = value.CompareTo(current.Key);
            if (cmp == 0)
            {
                current.Values.AddLast(value);
                _count++;
                return;
            }
            else if (cmp < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new Node(value);
                    _count++;
                    return;
                }
                current = current.Left;
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new Node(value);
                    _count++;
                    return;
                }
                current = current.Right;
            }
        }
    }

    /** Returns true if the value exists in the tree
     * TC: Best O(1) Worst O(n) */
    public bool Contains(T value)
    {
        Node? current = _root;
        while (current != null)
        {
            int cmp = value.CompareTo(current.Key);
            if (cmp == 0) return true;
            current = cmp < 0 ? current.Left : current.Right;
        }
        return false;
    }

    /** Removes a single occurrence of value from the tree. If a node contains multiple duplicates,
     * only one instance is removed. Returns true if removed.
     * TC: Best O(1) Worst O(n) */
    public bool Remove(T value)
    {
        Node? parent = null;
        Node? current = _root;

        while (current != null && value.CompareTo(current.Key) != 0)
        {
            parent = current;
            current = value.CompareTo(current.Key) < 0 ? current.Left : current.Right;
        }

        if (current == null) return false;

        // If there are duplicates stored in the node, remove one occurrence from the list
        if (current.Values.Count > 1)
        {
            current.Values.Remove(value);
            _count--;
            return true;
        }

        // Node has single value; we will remove the node from the tree
        _count--; // remove the one value

        DeleteNode(current, parent, doDecrementCount: false);
        return true;
    }

    // Helper to delete a node given its parent. If doDecrementCount is true, subtract node.Values.Count from _count.
    private void DeleteNode(Node node, Node? parent, bool doDecrementCount)
    {
        if (doDecrementCount)
        {
            _count -= node.Values.Count;
        }

        // Case 1: no children
        if (node.Left == null && node.Right == null)
        {
            if (parent == null) _root = null;
            else if (ReferenceEquals(parent.Left, node)) parent.Left = null;
            else parent.Right = null;
            return;
        }

        // Case 2: one child
        if (node.Left == null || node.Right == null)
        {
            Node? child = node.Left ?? node.Right;
            if (parent == null)
            {
                _root = child;
            }
            else if (ReferenceEquals(parent.Left, node))
            {
                parent.Left = child;
            }
            else
            {
                parent.Right = child;
            }
            return;
        }

        // Case 3: two children -> find successor (smallest in right subtree)
        Node succParent = node;
        Node succ = node.Right!;
        while (succ.Left != null)
        {
            succParent = succ;
            succ = succ.Left;
        }

        // Move successor's key and values into current node
        node.Key = succ.Key;
        node.Values = succ.Values;

        // Delete successor node; successor has at most one child (right)
        if (ReferenceEquals(succParent.Left, succ))
            succParent.Left = succ.Right;
        else
            succParent.Right = succ.Right;

        // Note: do not change _count here because we already adjusted for the removed value above
    }

    /** Total number of values stored in the tree (includes duplicates)
     * TC: Best O(1) Worst O(1) */
    public int Count => _count;

    /** Clears the tree
     * TC: Best O(1) Worst O(n) */
    public void Clear()
    {
        _root = null;
        _count = 0;
    }

    /** Returns an in-order enumerator over all values in the tree (duplicates are yielded)
     * TC: Best O(1) Worst O(n) per enumeration */
    public IEnumerator<T> GetEnumerator()
    {
        return InOrder(_root).GetEnumerator();
    }

    private IEnumerable<T> InOrder(Node? node)
    {
        if (node == null) yield break;
        foreach (var v in InOrder(node.Left)) yield return v;
        // iterate over the internal linked list
        foreach (var v in node.Values) yield return v;
        foreach (var v in InOrder(node.Right)) yield return v;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}