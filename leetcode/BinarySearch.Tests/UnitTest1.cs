namespace BinarySearch.Tests;

public class Solution
{
    public int BinarySearch(int[] input, int target)
    {
        var left = 0;
        var right = input.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (input[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return left;
    }
}

public class Tests
{
    [TestCase(new int[] { }, 2, 0)]
    [TestCase(new[] { 1, 2, 2, 3, 4, }, 2, 1)]
    [TestCase(new[] { 2, 2, 2, 3, 4, }, 2, 0)]
    [TestCase(new[] { 2, 2, 2, 3, 4, }, 5, 5)]
    [TestCase(new[] { 2, 2, 2, 3, 4, }, 10, 5)]
    [TestCase(new[] { 2, 2, 2, 3, 4, }, 0, 0)]
    [TestCase(new[] { 1, 2, 2, 2, 3, 4, }, -1, 0)]
    [TestCase(new[] { 1, 2, 2, 2, 4, 5 }, 3, 4)]
    public void Test1(int[] input, int target, int expected)
    {
        var actual = new Solution().BinarySearch(input, target);
        Assert.That(actual, Is.EqualTo(expected));
    }
}