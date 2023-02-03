using NUnit.Framework;

namespace MedianOfTwoSortedArrays.Tests;

public class Tests
{
    [TestCase(new int[0], new[] { 1 }, 1)]
    [TestCase(new int[0], new[] { 1, 2 }, 1.5)]
    [TestCase(new[] { 3 }, new int[0], 3)]
    [TestCase(new[] { 1 }, new[] { 1, 2, 3 }, 1.5)]
    [TestCase(new[] { 1, 2 }, new[] { 2, 3 }, 2)]
    [TestCase(new[] { 1, 2 }, new[] { 3, 4, 5 }, 3)]
    [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3, 4 }, 3.5)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 10 }, 2.5)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 10, 11 }, 3)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, 3.5)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 2, 3, 4, 7, 8 }, 4.5)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 4, 5, 6, 7 }, 5)]
    [TestCase(new[] { 3, 3, 3, 3 }, new[] { 3, 3, 3, 3 }, 3)]
    [TestCase(new[] { 3, 3, 3, 3 }, new[] { 3, 3, 3, 3 }, 3)]
    [TestCase(new[] { 1, 4, 5, 6 }, new[] { 2, 3, 7, 8 }, 4.5)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 6 }, 3.5)]
    public void Test_000(int[] arr1, int[] arr2, decimal expected)
    {
        var actual = new Solution().FindMedianSortedArrays_000(arr1, arr2);
        Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[0], new[] { 1 }, 1)]
    [TestCase(new int[0], new[] { 1, 2 }, 1.5)]
    [TestCase(new[] { 3 }, new int[0], 3)]
    [TestCase(new[] { 1 }, new[] { 1, 2, 3 }, 1.5)]
    [TestCase(new[] { 1 }, new[] { 1, 2, 3, 4 }, 2)]
    [TestCase(new[] { 1, 2 }, new[] { 2, 3 }, 2)]
    [TestCase(new[] { 1, 2 }, new[] { 3, 4, 5 }, 3)]
    [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3, 4 }, 3.5)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 10 }, 2.5)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 10, 11 }, 3)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, 3.5)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 2, 3, 4, 7 }, 4)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 2, 3, 4, 7, 8 }, 4.5)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 4, 5, 6, 7 }, 5)]
    [TestCase(new[] { 3, 3, 3, 3 }, new[] { 3, 3, 3, 3 }, 3)]
    [TestCase(new[] { 3, 3, 3, 3 }, new[] { 4, 4, 4, 4 }, 3.5)]
    [TestCase(new[] { 1, 4, 5, 6 }, new[] { 2, 3, 7, 8 }, 4.5)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 6 }, 3.5)]
    public void Test_001(int[] arr1, int[] arr2, decimal expected)
    {
        var actual = new Solution().FindMedianSortedArrays_001(arr1, arr2);
        Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[0], new[] { 1 }, 1)]
    [TestCase(new int[0], new[] { 1, 2 }, 1.5)]
    [TestCase(new[] { 3 }, new int[0], 3)]
    [TestCase(new[] { 1 }, new[] { 1, 2, 3 }, 1.5)]
    [TestCase(new[] { 1 }, new[] { 1, 2, 3, 4 }, 2)]
    [TestCase(new[] { 1, 2 }, new[] { 2, 3 }, 2)]
    [TestCase(new[] { 1, 2 }, new[] { 3, 4, 5 }, 3)]
    [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3, 4 }, 3.5)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 10 }, 2.5)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 10, 11 }, 3)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, 3.5)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 2, 3, 4, 7 }, 4)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 2, 3, 4, 7, 8 }, 4.5)]
    [TestCase(new[] { 1, 5, 6 }, new[] { 4, 5, 6, 7 }, 5)]
    [TestCase(new[] { 3, 3, 3, 3 }, new[] { 3, 3, 3, 3 }, 3)]
    [TestCase(new[] { 3, 3, 3, 3 }, new[] { 4, 4, 4, 4 }, 3.5)]
    [TestCase(new[] { 1, 4, 5, 6 }, new[] { 2, 3, 7, 8 }, 4.5)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 6 }, 3.5)]
    public void Test_002(int[] arr1, int[] arr2, decimal expected)
    {
        var actual = new Solution().FindMedianSortedArrays_002(arr1, arr2);
        Assert.AreEqual(expected, actual);
    }
}