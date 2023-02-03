using NUnit.Framework;

namespace A.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var deque = new Deque(1);
        var result = deque.PushBack(3);
        Assert.True(result);
    }

    [Test]
    public void Test2()
    {
        var deque = new Deque(1);
        deque.PushBack(3);
        var result = deque.PushBack(4);
        Assert.False(result);
    }

    [Test]
    public void Test3()
    {
        var deque = new Deque(1);
        var result = deque.PushFront(3);
        Assert.True(result);
    }

    [Test]
    public void Test4()
    {
        var deque = new Deque(1);
        deque.PushBack(3);
        var result = deque.PushFront(4);
        Assert.False(result);
    }

    [Test]
    public void Test5()
    {
        var deque = new Deque(1);
        deque.PushBack(3);
        var result = deque.PopBack();
        Assert.AreEqual(3, result);
    }

    [Test]
    public void Test6()
    {
        var deque = new Deque(1);
        deque.PushBack(3);
        deque.PopBack();
        var result = deque.PopBack();
        Assert.IsNull(result);
    }

    [Test]
    public void Test7()
    {
        var deque = new Deque(1);
        deque.PushFront(3);
        var result = deque.PopFront();
        Assert.AreEqual(3, result);
    }

    [Test]
    public void Test8()
    {
        var deque = new Deque(1);
        deque.PushFront(3);
        deque.PopFront();
        var result = deque.PopFront();
        Assert.IsNull(result);
    }
}