using System;
using Xunit;
using AbstractDataTypes.list;

namespace AbstractDataTypes.Tests;

public class ListTests
{
    [Fact]
    public void ArrayList_Add_Get_Count_Contains_Remove()
    {
        var list = new ArrayList<int>();
        Assert.Equal(0, list.Count);

        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.Equal(3, list.Count);
        Assert.Equal(1, list[0]);
        Assert.Equal(2, list[1]);
        Assert.Equal(3, list[2]);

        Assert.True(list.Contains(2));
        Assert.False(list.Contains(4));

        Assert.True(list.Remove(2));
        Assert.False(list.Remove(4));
        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void ArrayList_Insert_RemoveAt_Indexer_Set_Clear()
    {
        var list = new ArrayList<string>();
        list.Add("a");
        list.Add("c");
        list.Insert(1, "b");

        Assert.Equal(3, list.Count);
        Assert.Equal("b", list[1]);

        list[1] = "bb";
        Assert.Equal("bb", list[1]);

        list.RemoveAt(1);
        Assert.Equal(2, list.Count);
        Assert.Equal("c", list[1]);

        list.Clear();
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void LinkedList_Basics()
    {
        var list = new AbstractDataTypes.list.LinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Insert(1, 15);

        Assert.Equal(3, list.Count);
        Assert.Equal(10, list[0]);
        Assert.Equal(15, list[1]);
        Assert.Equal(20, list[2]);

        Assert.True(list.Contains(15));
        Assert.True(list.Remove(15));
        Assert.False(list.Contains(15));
        Assert.Equal(2, list.Count);

        list.RemoveAt(0);
        Assert.Equal(1, list.Count);
        list.Clear();
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void SortedList_Basics()
    {
        var list = new SortedList<int>();
        list.Add(5);
        list.Add(1);
        list.Add(3);

        Assert.Equal(3, list.Count);
        Assert.Equal(1, list[0]);
        Assert.Equal(3, list[1]);
        Assert.Equal(5, list[2]);

        Assert.True(list.Contains(3));
        Assert.True(list.Remove(3));
        Assert.False(list.Contains(3));
        Assert.Equal(2, list.Count);

        list.Clear();
        Assert.Equal(0, list.Count);
    }
}
