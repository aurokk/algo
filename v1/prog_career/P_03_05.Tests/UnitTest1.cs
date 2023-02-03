using System.Collections;

namespace P_03_05.Tests;

public class Tests
{
    [Test]
    public void Test_000()
    {
        var input = new Stack<int> { };
        var expected = new Stack<int> { };
        var actual = new Solution().Sort(input);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_001()
    {
        var input = new Stack<int>();
        input.Push(1);
        var expected = new Stack<int>();
        expected.Push(1);
        var actual = new Solution().Sort(input);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_002()
    {
        var input = new Stack<int>();
        input.Push(1);
        input.Push(2);
        input.Push(3);
        var expected = new Stack<int>();
        expected.Push(3);
        expected.Push(2);
        expected.Push(1);
        var actual = new Solution().Sort(input);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_003()
    {
        var input = new Stack<int>();
        input.Push(1);
        input.Push(3);
        input.Push(2);
        var expected = new Stack<int>();
        expected.Push(3);
        expected.Push(2);
        expected.Push(1);
        var actual = new Solution().Sort(input);
        CollectionAssert.AreEqual(expected, actual);
    }
}