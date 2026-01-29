using System.Linq;
using Xunit;
using AbstractDataTypes.Tree;

namespace AbstractDataTypes.Tests;

public class BSTTests
{
    [Fact]
    public void Add_Contains_Count()
    {
        var tree = new BST<int>();
        Assert.Equal(0, tree.Count);

        tree.Add(10);
        tree.Add(5);
        tree.Add(15);

        Assert.Equal(3, tree.Count);
        Assert.True(tree.Contains(10));
        Assert.True(tree.Contains(5));
        Assert.True(tree.Contains(15));
        Assert.False(tree.Contains(100));
    }

    [Fact]
    public void Duplicates_Add_Remove()
    {
        var tree = new BST<int>();
        tree.Add(5);
        tree.Add(5);
        tree.Add(5);

        Assert.Equal(3, tree.Count);
        var all = tree.ToArray();
        Assert.Equal(new[] { 5, 5, 5 }, all);

        // Remove one occurrence
        Assert.True(tree.Remove(5));
        Assert.Equal(2, tree.Count);
        Assert.Equal(new[] { 5, 5 }, tree.ToArray());

        // Remove remaining occurrences
        Assert.True(tree.Remove(5));
        Assert.True(tree.Remove(5));
        Assert.Equal(0, tree.Count);
        Assert.False(tree.Contains(5));

        // Removing non-existing returns false
        Assert.False(tree.Remove(5));
    }

    [Fact]
    public void Remove_NodeWithTwoChildren_ReplacesAndMaintainsOrder()
    {
        // Build a balanced-like tree
        var tree = new BST<int>();
        int[] values = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (var v in values) tree.Add(v);
        Assert.Equal(values.Length, tree.Count);

        // Remove root (50) which has two children
        Assert.True(tree.Remove(50));
        Assert.Equal(values.Length - 1, tree.Count);
        Assert.False(tree.Contains(50));

        var expected = values.Where(x => x != 50).OrderBy(x => x).ToArray();
        Assert.Equal(expected, tree.ToArray());
    }

    [Fact]
    public void InOrderEnumeration_IsSorted()
    {
        var tree = new BST<int>();
        int[] values = { 5, 3, 7, 2, 4, 6, 8 };
        foreach (var v in values) tree.Add(v);

        var enumerated = tree.ToArray();
        var expected = values.OrderBy(x => x).ToArray();
        Assert.Equal(expected, enumerated);
    }

    [Fact]
    public void Clear_EmptiesTree()
    {
        var tree = new BST<int>();
        tree.Add(1);
        tree.Add(2);
        tree.Add(3);
        Assert.Equal(3, tree.Count);

        tree.Clear();
        Assert.Equal(0, tree.Count);
        Assert.Empty(tree.ToArray());
    }
}
