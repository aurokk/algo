using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LargestNumber.Tests;

public class Tests
{
    [TestCase(new[] { 10, 2 }, "210")]
    [TestCase(new[] { 3, 30, 34, 5, 9 }, "9534330")]
    [TestCase(new[] { 9, 19, 991 }, "999119")]
    [TestCase(new[] { 1, 0, 0 }, "100")]
    [TestCase(new[] { 0, 0 }, "0")]
    public void Test_000(int[] input, string expected)
    {
        var actual = new Solution().LargestNumber_000(input);
        Assert.AreEqual(expected, actual);
    }

    [TestCase(new[] { 10, 2 }, "210")]
    [TestCase(new[] { 3, 30, 34, 5, 9 }, "9534330")]
    [TestCase(new[] { 9, 19, 991 }, "999119")]
    [TestCase(new[] { 1, 0, 0 }, "100")]
    [TestCase(new[] { 0, 0 }, "0")]
    public void Test_001(int[] input, string expected)
    {
        var actual = new Solution().LargestNumber_001(input);
        Assert.AreEqual(expected, actual);
    }

    [TestCase(new[] { 10, 2 }, new[] { 2, 10 })]
    [TestCase(new[] { 3, 30, 34, 5, 9 }, new[] { 3, 5, 9, 30, 34 })]
    [TestCase(new[] { 9, 991, 19 }, new[] { 9, 19, 991 })]
    [TestCase(new[] { 1, 0, 0 }, new[] { 0, 0, 1 })]
    [TestCase(new[] { 0, 0 }, new[] { 0, 0 })]
    public void Test_002(int[] actual, int[] expected)
    {
        Solution.QuickSort(actual, 0, actual.Length, Comparer<int>.Default);
        Assert.AreEqual(expected, actual);
    }
}