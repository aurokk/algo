namespace PartitionArrayIntoTwoArraysToMinimizeSumDifference.Tests;

public class Tests
{
    [TestCase(new[] { 3, 9, 7, 3 }, 2)]
    [TestCase(new[] { -36, 36 }, 72)]
    [TestCase(new[] { 2, -1, 0, 4, -2, -9 }, 0)]
    [TestCase(new[] { 25, 49, 39, 42, 57, 35 }, 1)]
    [TestCase(new[] { 7772197,4460211,-7641449,-8856364,546755,-3673029,527497,-9392076,3130315,-5309187,-4781283,5919119,3093450,1132720,6380128,-3954678,-1651499,-7944388,-3056827,1610628,7711173,6595873,302974,7656726,-2572679,0,2121026,-5743797,-8897395,-9699694 }, 1)]
    public void Test_000(int[] input, int expected)
    {
        var actual = new Solution().MinimumDifference_000(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}