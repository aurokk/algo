using NUnit.Framework;

namespace DeleteNodeInALinkedList.Tests;

public class Tests
{
    [TestCase(new char[0], new char[0])]
    [TestCase(new[] { '1' }, new[] { '1' })]
    [TestCase(new[] { '1', '2', }, new[] { '2', '1' })]
    [TestCase(new[] { '1', '2', '3' }, new[] { '3', '2', '1' })]
    [TestCase(new[] { '1', '2', '3', '4' }, new[] { '4', '3', '2', '1' })]
    public void Test_000(char[] input, char[] expected)
    {
        new Solution().ReverseString_000(input);
        Assert.AreEqual(expected, input);
    }
}