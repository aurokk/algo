using NUnit.Framework;

namespace TwoSum.Tests;

public class Tests
{
    [TestCase(new[] { 3, 2, 4, }, 6, new[] { 1, 2 })]
    [TestCase(new[] { 2, 7, 11, 15, }, 9, new[] { 0, 1 })]
    [TestCase(new[] { 2, 2, 7, 11, 15, }, 9, new[] { 0, 2 })]
    public void Test_0(int[] input, int target, int[] expected)
    {
        var solution = new Solution();
        var actual = solution.TwoSum_0(input, target);
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestCase(new[] { 3, 2, 4, }, 6, new[] { 1, 2 })]
    [TestCase(new[] { 2, 7, 11, 15, }, 9, new[] { 0, 1 })]
    [TestCase(new[] { 2, 2, 7, 11, 15, }, 9, new[] { 0, 2 })]
    public void Test_1(int[] input, int target, int[] expected)
    {
        var solution = new Solution();
        var actual = solution.TwoSum_1(input, target);
        CollectionAssert.AreEqual(expected, actual);
    }
}